using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amajuso.infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Title = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleFavorite",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ArticleId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleFavorite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    GoogleGuid = table.Column<string>(nullable: true),
                    FacebookGuid = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Terms = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ArticleCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFavorite",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ArticleCategoryId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Notification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryFavorite_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFavorite_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "Active", "Title" },
                values: new object[,]
                {
                    { 1L, true, "Judicial" },
                    { 2L, true, "Eventos" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "Email", "FacebookGuid", "Gender", "GoogleGuid", "LastName", "Name", "Password", "Phone", "Role", "Terms" },
                values: new object[,]
                {
                    { 1L, null, "admin@amajuso.com", null, "Masculino", null, "Amajuso", "Admin", "aqapsWNmq/CU6eh2dFWIR/wsPZ6QKLACwi8oiDJCZbo=", null, "Administrator", 0L },
                    { 2L, null, "visitor@amajuso.com", null, "Masculino", null, "Amajuso", "Visitante", "aqapsWNmq/CU6eh2dFWIR/wsPZ6QKLACwi8oiDJCZbo=", null, "Visitor", 0L }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleCategoryId", "Content", "Title", "UserId" },
                values: new object[] { 1L, 1L, "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>", "Primera noticia de Amajuso", 1L });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleCategoryId", "Content", "Title", "UserId" },
                values: new object[] { 2L, 2L, "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>", "Nueva charla por Zoom", 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleCategoryId",
                table: "Article",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserId",
                table: "Article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_Title",
                table: "ArticleCategories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFavorite_ArticleCategoryId",
                table: "CategoryFavorite",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFavorite_UserId",
                table: "CategoryFavorite",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ArticleFavorite");

            migrationBuilder.DropTable(
                name: "CategoryFavorite");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
