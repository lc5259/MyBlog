

namespace MyBlog.Server.Application.User.Dto;

public class AuthAccountPageQueryInput : Pagination
{
    /// <summary>
    /// 昵称
    /// </summary>
    public string Name { get; set; }
}