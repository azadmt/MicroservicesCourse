using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class add_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Delivery_Status",
                table: "Orders");

            migrationBuilder.EnsureSchema(
                name: "Shopping");
            migrationBuilder.EnsureSchema(
                name: "DeliveryManagement");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stocks",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "ProductGroups",
                newName: "ProductGroups",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItems",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "Shopping");

            migrationBuilder.RenameTable(
                name: "Couriers",
                newName: "Couriers",
                newSchema: "Shopping");

            migrationBuilder.CreateTable(
                schema: "DeliveryManagement",
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CourierId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_Deliveries_Orders_Id",
                    //    column: x => x.Id,
                    //    principalTable: "Orders",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.NoAction);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Stocks",
                schema: "Shopping",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Shopping",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductGroups",
                schema: "Shopping",
                newName: "ProductGroups");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "Shopping",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "Shopping",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Couriers",
                schema: "Shopping",
                newName: "Couriers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourierId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Delivery_Status",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
