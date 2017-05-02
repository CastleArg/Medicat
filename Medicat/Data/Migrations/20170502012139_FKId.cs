using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medicat.Data.Migrations
{
    public partial class FKId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administration_Medicine_MedicineId",
                table: "Administration");

            migrationBuilder.DropForeignKey(
                name: "FK_Administration_Patient_PatientId",
                table: "Administration");

            migrationBuilder.DropForeignKey(
                name: "FK_Administration_AspNetUsers_RecordedById",
                table: "Administration");

            migrationBuilder.DropIndex(
                name: "IX_Administration_MedicineId",
                table: "Administration");

            migrationBuilder.DropIndex(
                name: "IX_Administration_PatientId",
                table: "Administration");

            migrationBuilder.DropIndex(
                name: "IX_Administration_RecordedById",
                table: "Administration");

            migrationBuilder.DropColumn(
                name: "RecordedById",
                table: "Administration");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Administration",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Administration",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Administration",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Administration");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Administration",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Administration",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RecordedById",
                table: "Administration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administration_MedicineId",
                table: "Administration",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Administration_PatientId",
                table: "Administration",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Administration_RecordedById",
                table: "Administration",
                column: "RecordedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Administration_Medicine_MedicineId",
                table: "Administration",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Administration_Patient_PatientId",
                table: "Administration",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Administration_AspNetUsers_RecordedById",
                table: "Administration",
                column: "RecordedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
