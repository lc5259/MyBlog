using Furion.DatabaseAccessor;
using MyBlog.Server.Application.Blog.Dtos;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Blog
{
    public class ArticleService : BaseService<Article>
    {
        private readonly IRepository<Article> _repository;
        private readonly IIdGenerator _idGenerator;
        private readonly IRepository<Categories> _categoriesRepository;
        private readonly IRepository<ArticleCategory> _articleCategoryRepository;
        private readonly IRepository<ArticleTag> _articleTaRepositoryg;

        public ArticleService(IRepository<Article> repository, IIdGenerator idGenerator,
                                IRepository<Categories> categoriesRepository,
                                IRepository<ArticleCategory> articleCategoryRepository,
                                IRepository<ArticleTag> articleTaRepositoryg) : base(repository)
        {
            this._repository = repository;
            this._idGenerator = idGenerator;
            this._categoriesRepository = categoriesRepository;
            this._articleCategoryRepository = articleCategoryRepository;
            this._articleTaRepositoryg = articleTaRepositoryg;
        }

        /// <summary>
        /// 文章列表分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<ArticlePageOutput>> Page([FromQuery]ArticlePageQueryInput dto)
        { 
            List<long> categoryList = new List<long>();
            if (dto.CategoryId.HasValue)
            {
                 categoryList = await this._categoriesRepository.AsQueryable().Where(x => x.Status == AvailabilityStatus.Enable && x.ParentId == dto.CategoryId)
                    .Select(x => x.Id).ToListAsync();

                categoryList.Add(dto.CategoryId.Value);
            }

            var data = from a in this._repository.AsQueryable()
                       join ac in this._articleCategoryRepository.AsQueryable() on a.Id equals ac.ArticleId into results
                       from result in results.DefaultIfEmpty()
                       join c in this._categoriesRepository.AsQueryable() on result.CategoryId equals c.Id
                       where c.Status == AvailabilityStatus.Enable || (!string.IsNullOrWhiteSpace(dto.Title) && (a.Title.Contains(dto.Title)
                       || a.Summary.Contains(dto.Title) || a.Content.Contains(dto.Title)))
                       || (categoryList != null && categoryList.Contains(result.CategoryId))
                       orderby a.IsTop
                       orderby a.Sort
                       orderby a.PublishTime
                       select new ArticlePageOutput()
                       {
                           Id = a.Id,
                           Title = a.Title,
                           Status = a.Status,
                           Sort = a.Sort,
                           Cover = a.Cover,
                           IsTop = a.IsTop,
                           CreatedTime = a.CreatedTime,
                           CreationType = a.CreationType,
                           PublishTime = a.PublishTime,
                           Views = a.Views,
                           CategoryName = c.Name
                       };
            return await data.ToPagedListAsync();
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitOfWork]
        public async Task Add(AddArticleInput dto)
        {
            var article = dto.Adapt<Article>();
            article.Id = _idGenerator.NewLong();
            var tags = dto.Tags.Select(x => new ArticleTag()
            {
                ArticleId = article.Id,
                TagId = x
            }).ToList() ;
            await this._repository.InsertAsync(article);
            await this._articleTaRepositoryg.InsertAsync(tags);

            var articleCategory = new ArticleCategory()
            {
                ArticleId = article.Id,
                CategoryId = dto.CategoryId
            };
            await this._articleCategoryRepository.InsertAsync(articleCategory);

        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新文章")]
        [HttpPut("edit")]
        [UnitOfWork]
        public async Task Update(UpdateArticleInput dto)
        {
            var article = await _repository.FindOrDefaultAsync(dto.Id);
            if (article == null) throw Oops.Oh("无效参数");
            dto.Adapt(article);
            await _repository.UpdateAsync(article);

            var tags = dto.Tags.Select(x => new ArticleTag()
            {
                ArticleId = article.Id,
                TagId = x
            }).ToList();
            await this._articleTaRepositoryg.UpdateAsync(tags);

            var articleCategory = new ArticleCategory()
            {
                ArticleId = article.Id,
                CategoryId = dto.CategoryId
            };
            await this._articleCategoryRepository.UpdateAsync(articleCategory);

            Dictionary<string, string> dsg = new Dictionary<string, string>() { };
            
        }

        /// <summary>
        /// 文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ArticleDetailOutput> Detail([FromQuery] long id)
        {
            var data = from a in this._repository.AsQueryable()
                       join ac in this._articleCategoryRepository.AsQueryable() on a.Id equals ac.ArticleId into results
                       from reuslt in results
                       join c in this._categoriesRepository.AsQueryable() on reuslt.CategoryId equals c.Id
                       where c.Status == AvailabilityStatus.Enable && a.Id == id
                       select new ArticleDetailOutput()
                       {
                           Id = a.Id,
                           Title = a.Title,
                           Summary = a.Summary,
                           Cover = a.Cover,
                           Status = a.Status,
                           Link = a.Link,
                           IsTop = a.IsTop,
                           Sort = a.Sort,
                           Author = a.Author,
                           Content = a.Content,
                           IsAllowComments = a.IsAllowComments,
                           IsHtml = a.IsHtml,
                           CreationType = a.CreationType,
                           CategoryId = c.Id,
                           ExpiredTime = a.ExpiredTime,
                           PublishTime = a.PublishTime,
                           Tags = null
                           //       Tags = SqlFunc.Subqueryable<Tags>().InnerJoin<ArticleTag>((tags, at) => tags.Id == at.TagId)
                           //.Where((tags, at) => at.ArticleId == article.Id && tags.Status == AvailabilityStatus.Enable)
                           //.ToList(tags => tags.Id)
                       };
           return await data.FirstOrDefaultAsync();
        }
    }
}
