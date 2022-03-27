﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OxygenLab.Data.Migrations
{
    public partial class amount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Reagents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Reagents");
        }
    }
}
