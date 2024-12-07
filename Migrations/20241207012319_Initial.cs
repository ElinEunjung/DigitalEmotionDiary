using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalEmotionDiary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmotionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmotionTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BackgroundColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emotion_EmotionType_EmotionTypeId",
                        column: x => x.EmotionTypeId,
                        principalTable: "EmotionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryEntry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmotionId = table.Column<long>(type: "INTEGER", nullable: false),
                    EmotionId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Emotion_EmotionId1",
                        column: x => x.EmotionId1,
                        principalTable: "Emotion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiaryEntry_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiaryEntryId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_DiaryEntry_DiaryEntryId",
                        column: x => x.DiaryEntryId,
                        principalTable: "DiaryEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryTag",
                columns: table => new
                {
                    DiaryEntryId = table.Column<long>(type: "INTEGER", nullable: false),
                    TagId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTag", x => new { x.DiaryEntryId, x.TagId });
                    table.ForeignKey(
                        name: "FK_EntryTag_DiaryEntry_DiaryEntryId",
                        column: x => x.DiaryEntryId,
                        principalTable: "DiaryEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    UploadeAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiaryEntryId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_DiaryEntry_DiaryEntryId",
                        column: x => x.DiaryEntryId,
                        principalTable: "DiaryEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaryEntryId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_DiaryEntry_DiaryEntryId",
                        column: x => x.DiaryEntryId,
                        principalTable: "DiaryEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmotionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Happy" },
                    { 2, "Energized" },
                    { 3, "Tired" },
                    { 4, "Anxious" },
                    { 5, "Stressed" },
                    { 6, "Sad" },
                    { 7, "Annoyed" },
                    { 8, "Neutral" }
                });

            migrationBuilder.InsertData(
                table: "Emotion",
                columns: new[] { "Id", "BackgroundColor", "EmotionTypeId" },
                values: new object[,]
                {
                    { 1, "Yellow", 1 },
                    { 2, "Orange", 2 },
                    { 3, "Beige", 3 },
                    { 4, "Brown", 4 },
                    { 5, "Light Red", 5 },
                    { 6, "Grey/Black", 6 },
                    { 7, "Red", 7 },
                    { 8, "White", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_DiaryEntryId",
                table: "Comment",
                column: "DiaryEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_EmotionId1",
                table: "DiaryEntry",
                column: "EmotionId1");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_UserId",
                table: "DiaryEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emotion_EmotionTypeId",
                table: "Emotion",
                column: "EmotionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTag_TagId",
                table: "EntryTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_DiaryEntryId",
                table: "Image",
                column: "DiaryEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_DiaryEntryId",
                table: "Like",
                column: "DiaryEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "EntryTag");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "DiaryEntry");

            migrationBuilder.DropTable(
                name: "Emotion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EmotionType");
        }
    }
}
