using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalEmotionDiary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 907, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 907, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 907, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.InsertData(
                table: "DiaryEntry",
                columns: new[] { "Id", "Content", "CreatedAt", "EmotionId", "ImageId", "IsPublic", "Title", "UserId" },
                values: new object[,]
                {
                    { 4L, "Time to make kimchi for next year, I'm ready for the war!!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(5996), 1, null, true, "Kimchi day", 1L },
                    { 5L, "It's our family's yearly trip. Getting exceited!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6000), 1, null, true, "Trip to Jeju", 1L },
                    { 6L, "It's awful to get sick while I'm traveling.", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6004), 7, null, false, "Sickness", 2L },
                    { 7L, "We live only once in our life. Let's party today! yay!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6008), 2, null, true, "Party", 2L },
                    { 8L, "So exicted, I'm in the middle of shopping heaven!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6012), 2, null, true, "Shopping", 1L },
                    { 9L, "So exicted, I'm in the middle of shopping heaven!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6016), 2, null, true, "Chirstmas", 1L },
                    { 10L, "So exicted, I'm in the middle of shopping heaven!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6020), 2, null, true, "Oyster", 1L },
                    { 11L, "Food in Riga is best in my opinion!", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6024), 2, null, true, "Riga, my home", 2L },
                    { 12L, "work out everyday is so important. I don't want to get sick...", new DateTime(2024, 12, 18, 1, 11, 2, 899, DateTimeKind.Utc).AddTicks(6028), 8, null, false, "Healthy life", 2L }
                });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 915, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 915, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 18, 1, 11, 2, 915, DateTimeKind.Utc).AddTicks(6736));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 864, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 864, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 864, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 861, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 861, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 861, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 867, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 867, DateTimeKind.Utc).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 17, 6, 48, 15, 867, DateTimeKind.Utc).AddTicks(6528));
        }
    }
}
