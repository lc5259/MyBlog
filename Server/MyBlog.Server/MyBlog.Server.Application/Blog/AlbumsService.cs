using MyBlog.Server.Application.Blog.Dtos;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Blog
{
    /// <summary>
    /// 相册管理
    /// </summary>
    public class AlbumsService : BaseService<Albums>
    {
        private readonly IRepository<Albums> repository;

        public AlbumsService(IRepository<Albums> repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 相册列表分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<AlbumsPageOutput>> Page([FromQuery] AlbumsPageQueryInput dto )
        {
            return await this.repository.AsQueryable()
                .Where(!string.IsNullOrWhiteSpace(dto.Name),x=> x.Name.Contains(dto.Name))
                .Where(dto.Type.HasValue,x => x.Type == dto.Type)
                .OrderBy(x => x.Sort)
                .Select(x => new AlbumsPageOutput 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Status = x.Status,
                    IsVisible = x.IsVisible,
                    Sort = x.Sort,
                    Remark = x.Remark,
                    Cover = x.Cover,
                    CreatedTime = x.CreatedTime
                }
                ).ToPagedListAsync();

        }

        /// <summary>
        /// 新增相册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(AddAlbumsInput dto)
        {
            var albums = dto.Adapt<Albums>();
            await this.repository.InsertAsync(albums);
        }

        /// <summary>
        /// 更新相册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update(UpdateAlbumsInput dto)
        {
            var albums = await this.repository.FindOrDefaultAsync(dto.Id);
            if (albums == null)
            {
                throw Oops.Oh("无效参数");
            }
            albums = dto.Adapt<Albums>();
            await this.repository.UpdateAsync(albums);
        }
    }
}
