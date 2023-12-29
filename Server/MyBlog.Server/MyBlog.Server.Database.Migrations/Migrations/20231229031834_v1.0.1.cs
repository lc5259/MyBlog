using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Server.Database.Migrations.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsTop = table.Column<bool>(type: "bit", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(200)", nullable: true),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IsAllowComments = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OAuthId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBlogger = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<long>(type: "bigint", nullable: true),
                    RootId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    ReplyAccountId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Geolocation = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsMultiple = table.Column<bool>(type: "bit", nullable: false),
                    Json = table.Column<string>(type: "varchar(2000)", nullable: true),
                    AllowCreationEntity = table.Column<bool>(type: "bit", nullable: false),
                    IsGenerate = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomConfigItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigId = table.Column<long>(type: "bigint", nullable: false),
                    Json = table.Column<string>(type: "varchar(2000)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomConfigItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendLink",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsIgnoreCheck = table.Column<bool>(type: "bit", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Praise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    RouteName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(3128)", maxLength: 3128, nullable: true),
                    Component = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Redirect = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsIframe = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsKeepAlive = table.Column<bool>(type: "bit", nullable: false),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysOperationLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    LogLevel = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    HttpMethod = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TraceId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RequestUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RemoteIp = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    OsDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Elapsed = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: false),
                    Parameter = table.Column<string>(type: "varchar(200)", nullable: true),
                    Response = table.Column<string>(type: "varchar(200)", nullable: true),
                    Message = table.Column<string>(type: "varchar(200)", nullable: true),
                    Exception = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOperationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysOrganization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOrganization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    MenuId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysSigninLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RemoteIp = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OsDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysSigninLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    OrgId = table.Column<long>(type: "bigint", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastLoginIp = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LastLoginAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    LockExpired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysUserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTop = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "varchar(200)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsAllowComments = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeleteMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "AuthAccount");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CustomConfig");

            migrationBuilder.DropTable(
                name: "CustomConfigItem");

            migrationBuilder.DropTable(
                name: "FriendLink");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Praise");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysOperationLog");

            migrationBuilder.DropTable(
                name: "SysOrganization");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysRoleMenu");

            migrationBuilder.DropTable(
                name: "SysSigninLog");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "SysUserRole");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Talks");
        }
    }
}
