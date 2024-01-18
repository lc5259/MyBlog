using MyBlog.Server.Application.Auth;
using MyBlog.Server.Application.Blog.Dtos;
using MyBlog.Server.Core.Entities;

namespace MyBlog.Server.Application.Blog;

/// <summary>
/// 相册图片管理
/// </summary>
public class PicturesService : IDynamicApiController
{
    private readonly IRepository<Pictures> _repository;
    private readonly IRepository<Albums> _albumsRepository;
    private readonly AuthManager _authManager;

    public PicturesService(IRepository<Pictures> repository, IRepository<Albums> albumsRepository,
        AuthManager authManager)
    {
        _repository = repository;
        this._albumsRepository = albumsRepository;
        _authManager = authManager;
    }
    /// <summary>
    /// 相册图片分页
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<PagedList<PicturesPageOutput>> Page([FromQuery] PicturesPageQueryInput dto)
    {
        var data = from p in this._repository.AsQueryable()
                   join a in this._albumsRepository.AsQueryable() on p.AlbumId equals a.Id
                   where (_authManager.AuthPlatformType == null || _authManager.AuthPlatformType == AuthPlatformType.Blog)
                   select new PicturesPageOutput()
                   {
                       Id = p.Id,
                       Url = p.Url

                   };
        return await data.ToPagedListAsync();


        //return await _repository.AsQueryable().InnerJoin<Albums>((pictures, albums) => pictures.AlbumId == albums.Id)
        //    .Where(pictures => pictures.AlbumId == dto.Id)
        //    .WhereIF(_authManager.AuthPlatformType is null or AuthPlatformType.Blog, (pictures, albums) => albums.IsVisible)
        //    .Select(pictures => new PicturesPageOutput { Id = pictures.Id, Url = pictures.Url })
        //    .ToPagedListAsync(dto);
    }

    /// <summary>
    /// 上传图片到相册
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task Add(AddPictureInput dto)
    {
        var list = dto.Adapt<Pictures>();
        await _repository.InsertAsync(list);
    }

    /// <summary>
    /// 删除上册图片
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    public async Task Delete(KeyDto dto)
    {
        await _repository.DeleteAsync(dto.Id);
    }
}