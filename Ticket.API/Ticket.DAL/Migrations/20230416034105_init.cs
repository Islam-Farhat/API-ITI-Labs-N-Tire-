using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicket",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicket", x => new { x.DeveloperId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Department1" },
                    { 2, "Department2" },
                    { 3, "Department3" },
                    { 4, "Department4" },
                    { 5, "Department5" },
                    { 6, "Department6" },
                    { 7, "Department7" },
                    { 8, "Department8" },
                    { 9, "Department9" },
                    { 10, "Department10" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Asthma" },
                    { 4, "Depression" },
                    { 5, "Arthritis" },
                    { 6, "Allergy" },
                    { 7, "Flu" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DepartmentId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 5, "this my discription..", "Dana" },
                    { 2, 7, "this my discription..", "Isaac" },
                    { 3, 9, "this my discription..", "Damon" },
                    { 4, 8, "this my discription..", "Miriam" },
                    { 5, 7, "this my discription..", "Terence" },
                    { 6, 1, "this my discription..", "Roosevelt" },
                    { 7, 9, "this my discription..", "Eduardo" },
                    { 8, 8, "this my discription..", "Wilbert" },
                    { 9, 5, "this my discription..", "Tasha" },
                    { 10, 1, "this my discription..", "Max" },
                    { 11, 2, "this my discription..", "Bridget" },
                    { 12, 8, "this my discription..", "Juan" },
                    { 13, 10, "this my discription..", "Krystal" },
                    { 14, 10, "this my discription..", "Erma" },
                    { 15, 6, "this my discription..", "Orlando" },
                    { 16, 5, "this my discription..", "Marvin" },
                    { 17, 4, "this my discription..", "Lamar" },
                    { 18, 7, "this my discription..", "Joe" },
                    { 19, 8, "this my discription..", "Wendell" },
                    { 20, 4, "this my discription..", "Sandra" },
                    { 21, 6, "this my discription..", "Stephanie" },
                    { 22, 7, "this my discription..", "Ervin" },
                    { 23, 4, "this my discription..", "Beth" },
                    { 24, 7, "this my discription..", "Gretchen" },
                    { 25, 2, "this my discription..", "Gwendolyn" },
                    { 26, 7, "this my discription..", "Jerry" },
                    { 27, 6, "this my discription..", "Mitchell" },
                    { 28, 8, "this my discription..", "Maggie" },
                    { 29, 3, "this my discription..", "Sandy" },
                    { 30, 2, "this my discription..", "Lloyd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicket_TicketsId",
                table: "DeveloperTicket",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTicket");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
