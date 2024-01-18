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
    public class FriendLinkService : BaseService<FriendLink>
    {
        private readonly IRepository<FriendLink> _repository;

        public FriendLinkService(IRepository<FriendLink> repository) : base(repository)
        {
            this._repository = repository;
        }
        /// <summary>
        /// 友情链接分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("友情链接分页查询")]
        [HttpGet]
        public async Task<PagedList<FriendLinkPageOutput>> Page([FromQuery] FriendLinkPageQueryInput dto)
        {
            
            return await _repository.AsQueryable()
                  .Where(!string.IsNullOrWhiteSpace(dto.SiteName), x => x.SiteName.Contains(dto.SiteName))
                  .OrderByDescending(x => x.Id)
                  .Select(x => new FriendLinkPageOutput
                  {
                      Id = x.Id,
                      Status = x.Status,
                      SiteName = x.SiteName,
                      CreatedTime = x.CreatedTime,
                      IsIgnoreCheck = x.IsIgnoreCheck,
                      Link = x.Link,
                      Logo = x.Logo,
                      Url = x.Url,
                      Sort = x.Sort,
                      Remark = x.Remark
                  }).ToPagedListAsync();
        }

        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("添加友情链接")]
        [HttpPost("add")]
        public async Task Add(AddFriendLinkInput dto)
        {
            var link = dto.Adapt<FriendLink>();
            await _repository.InsertAsync(link);
        }

        [DisplayName("更新友情链接")]
        [HttpPut("edit")]
        public async Task Update(UpdateFriendLinkInput dto)
        {
            var link = await _repository.FindOrDefaultAsync(dto.Id);
            if (link == null) throw Oops.Oh("无效参数");
            dto.Adapt(link);
            await _repository.UpdateAsync(link);
        }
    }
}
