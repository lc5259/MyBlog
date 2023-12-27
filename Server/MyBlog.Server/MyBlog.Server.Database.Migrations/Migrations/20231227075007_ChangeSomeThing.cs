using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Server.Database.Migrations.Migrations
{
    public partial class ChangeSomeThing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "密码"),
                    roleid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色权限id"),
                    roleid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色权限名"),
                    user_infoid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "用户id"),
                    is_lock = table.Column<bool>(type: "bit", nullable: true, comment: "锁定"),
                    is_lock_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "锁定"),
                    last_login_time = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "上次登录时间"),
                    try_times = table.Column<int>(type: "int", nullable: true, comment: "尝试登录次数"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标签"),
                    preview_url = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "预览图"),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "大图"),
                    previewid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "预览图片id"),
                    imageid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "大图id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作业名"),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "开始时间"),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "结束时间"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "状态"),
                    error_msg = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "错误原因")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailVertification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    mail_address = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "邮箱地址"),
                    login_request = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "登录请求信息"),
                    expire_time = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "过期时间"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息内容"),
                    is_active = table.Column<bool>(type: "bit", nullable: true, comment: "是否激活"),
                    mail_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "激活类型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailVertification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageRemind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    receiverId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "接收人id"),
                    receiverId_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "接收人名称"),
                    is_read = table.Column<bool>(type: "bit", nullable: true, comment: "是否阅读"),
                    is_read_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "是否阅读"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息内容"),
                    message_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息类型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRemind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    hook = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "钩子地址"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "说明"),
                    robot_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "类型"),
                    robot_type_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "类型名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RobotMessageTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息内容"),
                    runtime = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "执行时间"),
                    message_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息类型"),
                    message_type_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "消息类型名称"),
                    robotid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "机器人"),
                    robotid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "机器人名称"),
                    job_state = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "任务状态"),
                    job_state_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "任务状态名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotMessageTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysAttrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    entityid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "实体id"),
                    entityid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "实体名"),
                    attr_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "字段类型"),
                    attr_length = table.Column<int>(type: "int", nullable: true, comment: "字段长度"),
                    isrequire = table.Column<bool>(type: "bit", nullable: true, comment: "是否必填"),
                    default_value = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "默认值"),
                    entityCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysAttrs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "描述"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    objectId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件对象"),
                    real_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "真实文件名"),
                    file_path = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件路径"),
                    hash_code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "哈希值"),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文件类型"),
                    content_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "内容类型"),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    parentid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "上级菜单"),
                    parentid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "上级菜单"),
                    router = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "路由地址"),
                    menu_index = table.Column<int>(type: "int", nullable: true, comment: "菜单索引"),
                    statecode = table.Column<bool>(type: "bit", nullable: true, comment: "状态"),
                    statecode_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "状态名称"),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "图标"),
                    SysMenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysMenu_SysMenu_SysMenuId",
                        column: x => x.SysMenuId,
                        principalTable: "SysMenu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SysParam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    sys_paramGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "选项集"),
                    sys_paramgroupid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "选项集名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysParam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysParamGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysParamGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "描述"),
                    is_basic = table.Column<bool>(type: "bit", nullable: true, comment: "是否基础角色"),
                    is_basic_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "是否基础角色"),
                    parent_roleid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "继承角色"),
                    parent_roleid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "继承角色")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRolePrivilege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    sys_roleid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色id"),
                    sys_roleid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色名"),
                    privilege = table.Column<int>(type: "int", nullable: true, comment: "权限值"),
                    objectid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "对象id"),
                    objectid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "对象名"),
                    object_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "对象类型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRolePrivilege", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    gender = table.Column<int>(type: "int", nullable: true, comment: "性别"),
                    gender_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "性别"),
                    realname = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "真实姓名"),
                    mailbox = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "邮箱"),
                    introduction = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "个人介绍"),
                    cellphone = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "手机号码"),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "头像"),
                    life_photo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "生活照"),
                    roleid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色权限id"),
                    github_id = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Github ID"),
                    gitee_id = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Gitee ID"),
                    roleid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色权限名"),
                    statecode = table.Column<bool>(type: "bit", nullable: true, comment: "启用"),
                    statecode_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "启用"),
                    is_lock_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersionScriptExecutionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称"),
                    is_success = table.Column<bool>(type: "bit", nullable: true, comment: "是否执行成功")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionScriptExecutionLog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysMenu_SysMenuId",
                table: "SysMenu",
                column: "SysMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUser");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropTable(
                name: "MailVertification");

            migrationBuilder.DropTable(
                name: "MessageRemind");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "RobotMessageTask");

            migrationBuilder.DropTable(
                name: "SysAttrs");

            migrationBuilder.DropTable(
                name: "SysConfig");

            migrationBuilder.DropTable(
                name: "SysEntity");

            migrationBuilder.DropTable(
                name: "SysFile");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysParam");

            migrationBuilder.DropTable(
                name: "SysParamGroup");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysRolePrivilege");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "VersionScriptExecutionLog");
        }
    }
}
