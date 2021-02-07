using Microsoft.EntityFrameworkCore.Migrations;

namespace ISM_Vison.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    CameraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassType = table.Column<string>(type: "TEXT", nullable: true),
                    CameraName = table.Column<string>(type: "TEXT", nullable: true),
                    ExposureTime = table.Column<string>(type: "TEXT", nullable: true),
                    CailbFile = table.Column<string>(type: "TEXT", nullable: true),
                    CameraType = table.Column<string>(type: "TEXT", nullable: true),
                    Field0 = table.Column<string>(type: "TEXT", nullable: true),
                    Field1 = table.Column<string>(type: "TEXT", nullable: true),
                    Field2 = table.Column<string>(type: "TEXT", nullable: true),
                    Field3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.CameraId);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    SequenceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Product = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CameraId = table.Column<int>(type: "INTEGER", nullable: false),
                    Field0 = table.Column<string>(type: "TEXT", nullable: true),
                    Field1 = table.Column<string>(type: "TEXT", nullable: true),
                    Field2 = table.Column<string>(type: "TEXT", nullable: true),
                    Field3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.SequenceId);
                });

            migrationBuilder.CreateTable(
                name: "IFunc_ObjTypeStrings",
                columns: table => new
                {
                    IFunc_ObjTypeStringId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: true),
                    parameter = table.Column<string>(type: "TEXT", nullable: true),
                    SequenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IFunc_ObjTypeStrings", x => x.IFunc_ObjTypeStringId);
                    table.ForeignKey(
                        name: "FK_IFunc_ObjTypeStrings_Sequences_SequenceId",
                        column: x => x.SequenceId,
                        principalTable: "Sequences",
                        principalColumn: "SequenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IFunc_ObjTypeStrings_SequenceId",
                table: "IFunc_ObjTypeStrings",
                column: "SequenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "IFunc_ObjTypeStrings");

            migrationBuilder.DropTable(
                name: "Sequences");
        }
    }
}
