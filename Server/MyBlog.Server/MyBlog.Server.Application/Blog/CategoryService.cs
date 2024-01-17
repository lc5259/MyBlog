using Mapster;
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
    /// <summary>
/// 文章栏目管理
/// </summary>
    public class CategoryService : BaseService<Categories>
    {
        private readonly IRepository<Categories> _repository;

        public CategoryService(IRepository<Categories> repository) : base(repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 文章栏目列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<CategoryPageOutput>> Page([FromQuery] string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var list = await this._repository.AsQueryable().Where(x => x.Name == name).ToListAsync();
                return list.Adapt<List<CategoryPageOutput>>();
            }

            var data =  await this._repository.AsQueryable().Include(x => x.Children).OrderBy(x => x.Sort)
                .OrderBy(x => x.Id).ToListAsync();
            return data.Adapt<List<CategoryPageOutput>>();
        }

        /// <summary>
        /// 添加文章栏目
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("添加文章栏目")]
        [HttpPost("add")]
        public async Task Add(AddCategoryInput dto)
        {
            var entity = dto.Adapt<Categories>();
            await _repository.InsertAsync(entity);
        }

        /// <summary>
        /// 更新文章栏目
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新文章栏目")]
        [HttpPut("edit")]
        public async Task Update(UpdateCategoryInput dto)
        {
            var entity = await _repository.FindOrDefaultAsync(dto.Id);
            if (entity == null) throw Oops.Bah("无效参数");
            dto.Adapt(entity);
            await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 获取文章栏目下拉选项
        /// </summary>
        /// <returns></returns>
        [DisplayName("获取文章栏目下拉选项")]
        [HttpGet]
        public async Task<List<TreeSelectOutput>> TreeSelect()
        {
            //递归查询
            var list = await this._repository.AsQueryable().Include(x => x.Children).Where(u => u.Id == 1).Select(x => x.Children).FirstAsync();
          
            return list.Adapt<List<TreeSelectOutput>>();
        }

    }
}
