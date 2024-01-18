using MyBlog.Server.Application.Auth;
using MyBlog.Server.Application.Blog.Dtos;

namespace MyBlog.Server.Application.Blog;

/// <summary>
/// 说说管理
/// </summary>
public class TalksService : BaseService<Talks>
{
    private readonly IRepository<Talks> _repository;
    private readonly AuthManager _authManager;

    public TalksService(IRepository<Talks> repository, AuthManager authManager) : base(repository)
    {
        _repository = repository;
        _authManager = authManager;
    }

    /// <summary>
    /// 说说分页查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedList<TalksPageOutput>> Page([FromQuery] TalksPageQueryInput dto)
    {
        long userId = _authManager.UserId;
        return await _repository.AsQueryable()
              .Where(!string.IsNullOrWhiteSpace(dto.Keyword), x => x.Content.Contains(dto.Keyword))
              .OrderByDescending(x => x.Id)
              .Select(x => new TalksPageOutput
              {
                  Id = x.Id,
                  Status = x.Status,
                  Content = x.Content,
                  Images = x.Images,
                  IsAllowComments = x.IsAllowComments,
                  IsTop = x.IsTop,
                  IsPraise = true, //默认值。以后调试时候再改
                  //IsPraise = SqlFunc.Subqueryable<Praise>().Where(p => p.ObjectId == x.Id && p.AccountId == userId).Any(),
                  CreatedTime = x.CreatedTime
              }).ToPagedListAsync();
    }

    /// <summary>
    /// 添加说说
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task Add(AddTalksInput dto)
    {
        var talks = dto.Adapt<Talks>();
        await _repository.InsertAsync(talks);
    }

    /// <summary>
    /// 更新说说
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("edit")]
    public async Task Update(UpdateTalksInput dto)
    {
        var talks = await _repository.FindAsync(dto.Id);
        dto.Adapt(talks);
        await _repository.UpdateAsync(talks);
    }
}