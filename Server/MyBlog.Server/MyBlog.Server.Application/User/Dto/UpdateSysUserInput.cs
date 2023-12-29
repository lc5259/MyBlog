namespace MyBlog.Server.Application.User.Dto;

public class UpdateSysUserInput : AddSysUserInput
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public long Id { get; set; }
}