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
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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
                    EmotionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Emotion_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaryEntryId = table.Column<long>(type: "INTEGER", nullable: false),
                    TagId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTag", x => x.Id);
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
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
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
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "news" },
                    { 2L, "shocking" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "ProfileImagePath", "UserName" },
                values: new object[,]
                {
                    { 1L, "elin@gmail.com", "pass1", "elinProfile.png", "Elin" },
                    { 2L, "ivan@gmail.com", "pass2", "ivanProfile.png", "Ivan" }
                });

            migrationBuilder.InsertData(
                table: "Emotion",
                columns: new[] { "Id", "BackgroundColor", "EmotionTypeId" },
                values: new object[,]
                {
                    { 1, "#ffd700", 1 },
                    { 2, "#ff7f50", 2 },
                    { 3, "#c39797", 3 },
                    { 4, "#794044", 4 },
                    { 5, "#ff4040", 5 },
                    { 6, "#808080", 6 },
                    { 7, "#ff0000", 7 },
                    { 8, "#eeeeee", 8 }
                });

            migrationBuilder.InsertData(
                table: "DiaryEntry",
                columns: new[] { "Id", "Content", "CreatedAt", "EmotionId", "ImageId", "IsPublic", "Title", "UserId" },
                values: new object[,]
                {
                    { 1L, "Han Kang, South korean writer won the Nobel Prize in Literature! I'm so proud of her", new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(8888), 1, 1L, true, "Good news", 1L },
                    { 2L, "An idiot declared martial law today, luckly paliament overruled it in two hours, could save our democracy at the end. What a drama! ", new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(9675), 4, 2L, true, "A complete shock", 1L },
                    { 3L, "I adapted new cat, she's so adorable!", new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(9679), 2, 3L, true, "Maya", 2L }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "CreatedAt", "DiaryEntryId", "UserId" },
                values: new object[,]
                {
                    { 1L, "Congraturation! Woohoo!", new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(7896), 1L, 2L },
                    { 2L, "We need to fight for democracy!", new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(8296), 2L, 2L },
                    { 3L, "awwww so happy for you!", new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(8299), 2L, 1L }
                });

            migrationBuilder.InsertData(
                table: "EntryTag",
                columns: new[] { "Id", "DiaryEntryId", "TagId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L },
                    { 3L, 3L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "Description", "DiaryEntryId", "Path", "UploadedAt" },
                values: new object[,]
                {
                    { 1L, "writer Han Kang", 1L, "./Resources/Images/hankang.webp", new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(6579) },
                    { 2L, "the night under martial law", 2L, "./Resources/Images/120324.png", new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(7172) },
                    { 3L, "maja", 3L, "./Resources/Images/maja.jpeg", new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(7175) }
                });

            migrationBuilder.InsertData(
                table: "Like",
                columns: new[] { "Id", "DiaryEntryId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, 2L },
                    { 2L, 2L, 2L }
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
                name: "IX_DiaryEntry_EmotionId",
                table: "DiaryEntry",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_UserId",
                table: "DiaryEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emotion_EmotionTypeId",
                table: "Emotion",
                column: "EmotionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntryTag_DiaryEntryId",
                table: "EntryTag",
                column: "DiaryEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTag_TagId",
                table: "EntryTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_DiaryEntryId",
                table: "Image",
                column: "DiaryEntryId",
                unique: true);

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
