using Microsoft.EntityFrameworkCore;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Blog
{
    /// <summary>
    /// 文章所属栏目
    /// </summary>
    public class ArticleCategoryService : ITransient
    {
        private readonly IRepository<ArticleCategory> repository;

        public ArticleCategoryService(IRepository<ArticleCategory> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加文章所属栏目
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>

        public async Task Add(long articleId, long categoryId)
        {
            await this.repository.InsertAsync(new ArticleCategory()
            {
                ArticleId = articleId,
                CategoryId = categoryId
            });
        }
        
        /// <summary>
        /// 更新文章所属栏目
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task Update(long articleId, long categoryId)
        {
            var articleCategeory = await this.repository.Entities.FindAsync(articleId);
            if (articleCategeory == null)
            {
                throw Oops.Oh("文章所属栏目不存在");
            }
            articleCategeory.ArticleId = articleId;
            articleCategeory.CategoryId= categoryId;
       
            await repository.UpdateAsync(articleCategeory);
        }
    }
}
