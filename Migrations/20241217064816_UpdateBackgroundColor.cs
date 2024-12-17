using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalEmotionDiary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBackgroundColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 1,
                column: "BackgroundColor",
                value: "Yellow");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundColor",
                value: "Orange");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 3,
                column: "BackgroundColor",
                value: "Beige");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 4,
                column: "BackgroundColor",
                value: "Brown");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 5,
                column: "BackgroundColor",
                value: "Red");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 6,
                column: "BackgroundColor",
                value: "Grey");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 7,
                column: "BackgroundColor",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 8,
                column: "BackgroundColor",
                value: "White");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 598, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "DiaryEntry",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 594, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 1,
                column: "BackgroundColor",
                value: "#ffd700");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundColor",
                value: "#ff7f50");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 3,
                column: "BackgroundColor",
                value: "#c39797");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 4,
                column: "BackgroundColor",
                value: "#794044");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 5,
                column: "BackgroundColor",
                value: "#ff4040");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 6,
                column: "BackgroundColor",
                value: "#808080");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 7,
                column: "BackgroundColor",
                value: "#ff0000");

            migrationBuilder.UpdateData(
                table: "Emotion",
                keyColumn: "Id",
                keyValue: 8,
                column: "BackgroundColor",
                value: "#eeeeee");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UploadedAt",
                value: new DateTime(2024, 12, 15, 13, 34, 46, 602, DateTimeKind.Utc).AddTicks(7175));
        }
    }
}
