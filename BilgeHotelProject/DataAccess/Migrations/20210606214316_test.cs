using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Rooms_RoomID",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Guests",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_RoomID",
                table: "Guests",
                newName: "IX_Guests_RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Rooms_RoomId",
                table: "Guests",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Rooms_RoomId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Guests",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_RoomId",
                table: "Guests",
                newName: "IX_Guests_RoomID");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingId",
                table: "Guests",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Rooms_RoomID",
                table: "Guests",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
