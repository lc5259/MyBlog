using MyBlog.Server.Core.Entities.Interface;
using MyBlog.Server.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application
{
    public abstract class BaseService<TEntity> : IDynamicApiController where TEntity : MyBlog.Server.Core.Entities.Abstract.DEntityBase<long>, ISoftDelete, IAvailability, new()
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("删除信息"), HttpDelete("delete")]
        public virtual async Task Delete(KeyDto dto)
        {
            try 
            { 
                await _repository.DeleteAsync(dto);
                await ClearCache();
            } 
            catch 
            {
                throw Oops.Bah("删除失败");
            }
            //await _repository.DeleteNowAsync(dto.Id);

            //bool success = await _repository.UpdateAsync(x => new TEntity()
            //{
            //    DeleteMark = true
            //}, x => x.Id == dto.Id);
            //if (!success)
            //{
            //    throw Oops.Bah("删除失败");
            //}
            //await ClearCache();
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("修改状态"), HttpPatch("setStatus")]
        public virtual async Task SetStatus(AvailabilityDto dto)
        {
            //await _repository.UpdateIncludeAsync(new TEntity(), new[] { "Age", "Name" });

            //bool success = await _repository.UpdateAsync(x => new TEntity()
            //{
            //    Status = dto.Status
            //}, x => x.Id == dto.Id);
            //if (!success)
            //{
            //    throw Oops.Bah("修改失败");
            //}
            //await ClearCache();
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        internal virtual Task ClearCache()
        {
            return Task.CompletedTask;
        }

    }
}
