using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Server.Database.Migrations.Migrations
{
    public partial class v111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysAttrs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysAttrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attr_length = table.Column<int>(type: "int", nullable: true, comment: "字段长度"),
                    attr_type = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "字段类型"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "编码"),
                    default_value = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "默认值"),
                    entityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entityid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "实体id"),
                    entityid_name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "实体名"),
                    isrequire = table.Column<bool>(type: "bit", nullable: true, comment: "是否必填"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysAttrs", x => x.Id);
                });
        }
    }
}
