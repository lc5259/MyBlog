using MyBlog.Server.Application.Client.Dtos;
using Furion.UnifyResult;
using MyBlog.Server.Core.Entities;

namespace MyBlog.Server.Application.Client;

/// <summary>
/// 相册
/// </summary>
[ApiDescriptionSettings("博客前端接口")]
[AllowAnonymous]
public class AlbumsController : IDynamicApiController
{
    private readonly IRepository<Albums> _albumsRepository;
    private readonly IRepository<Pictures> _picturesRepository;

    public AlbumsController(IRepository<Albums> albumsRepository, IRepository<Pictures> picturesRepository)
    {
        _albumsRepository = albumsRepository;
        this._picturesRepository = picturesRepository;
    }

    /// <summary>
    /// 相册列表
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedList<AlbumsOutput>> Get([FromQuery] Pagination dto)
    {
        return await _albumsRepository.AsQueryable().Where(x => x.IsVisible && x.Status == AvailabilityStatus.Enable)
              .OrderBy(x => x.Sort)
              .OrderByDescending(x => x.Id)
              .Select(x => new AlbumsOutput
              {
                  Id = x.Id,
                  Name = x.Name,
                  Cover = x.Cover,
                  Remark = x.Remark,
                  CreatedTime = x.CreatedTime
              }).ToPagedListAsync();
    }

    /// <summary>
    /// 相册下的图片
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedList<PictureOutput>> Pictures([FromQuery] PicturesQueryInput dto)
    {
        var album = await _albumsRepository.AsQueryable().Where(x => x.Id == dto.AlbumId && x.IsVisible && x.Status == AvailabilityStatus.Enable).Select(x => new
        {
            x.Name,
            x.Cover
        }).FirstAsync();
        UnifyContext.Fill(album);
        var data = from albums in this._albumsRepository.AsQueryable()
                   join p in this._picturesRepository.AsQueryable() on albums.Id equals p.AlbumId
                   where (albums.IsVisible && albums.Status == AvailabilityStatus.Enable && albums.Id == dto.AlbumId)
                   orderby p.Id
                   select new PictureOutput()
                   {
                       Id = p.Id,
                       Url = p.Url
                   };


        return  await data.ToPagedListAsync();
    }
}