using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApplication.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Item_ReturnItemId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_User_UserId",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "Alias");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ReturnItemId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ReturnItemId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ReturnReason",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Item",
                newName: "StoreCode");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoice",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Invoice",
                newName: "InvoiceDate");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                newName: "IX_Invoice_StoreId");

            migrationBuilder.CreateTable(
                name: "DayData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precipitation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retail = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceId1",
                        column: x => x.InvoiceId1,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId1",
                table: "InvoiceItem",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ItemId",
                table: "InvoiceItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Store_StoreId",
                table: "Invoice",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Store_StoreId",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "DayData");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.RenameColumn(
                name: "StoreCode",
                table: "Item",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Invoice",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "Invoice",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_StoreId",
                table: "Invoice",
                newName: "IX_Invoice_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReturnItemId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReturnReason",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Alias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alias_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ReturnItemId",
                table: "Invoice",
                column: "ReturnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Alias_UserId",
                table: "Alias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Item_ReturnItemId",
                table: "Invoice",
                column: "ReturnItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_User_UserId",
                table: "Invoice",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
