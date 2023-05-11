using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Estoque.Data.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", nullable: false),
                    ShortDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    DocId = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    DocId = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxs",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", nullable: false),
                    Percentage = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxs_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalSchema: "public",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriesAdresss",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Street = table.Column<string>(type: "varchar(250)", nullable: false),
                    Number = table.Column<string>(type: "varchar(5)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(250)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(250)", nullable: false),
                    District = table.Column<string>(type: "varchar(250)", nullable: false),
                    City = table.Column<string>(type: "varchar(250)", nullable: false),
                    County = table.Column<string>(type: "varchar(250)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(250)", nullable: false),
                    Latitude = table.Column<string>(type: "varchar(250)", nullable: false),
                    Longitude = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesAdresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesAdresss_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesAdresss_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", nullable: false),
                    ShortDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Weight = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Height = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Length = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    Image = table.Column<string>(type: "varchar(5000)", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompany = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "public",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalSchema: "public",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalSchema: "public",
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerAdress",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Street = table.Column<string>(type: "varchar(250)", nullable: false),
                    Number = table.Column<string>(type: "varchar(5)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(250)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(250)", nullable: false),
                    District = table.Column<string>(type: "varchar(250)", nullable: false),
                    City = table.Column<string>(type: "varchar(250)", nullable: false),
                    County = table.Column<string>(type: "varchar(250)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(250)", nullable: false),
                    Latitude = table.Column<string>(type: "varchar(250)", nullable: false),
                    Longitude = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAdress_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerAdress_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    TotalTax = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    SaleType = table.Column<int>(type: "INT", nullable: false),
                    PaymentType = table.Column<int>(type: "INT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventories_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventories_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sales_IdSale",
                        column: x => x.IdSale,
                        principalSchema: "public",
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sales_SaleId1",
                        column: x => x.SaleId1,
                        principalSchema: "public",
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAdresss_CompanyId1",
                schema: "public",
                table: "CategoriesAdresss",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesAdresss_IdCompany",
                schema: "public",
                table: "CategoriesAdresss",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdress_CustomerId1",
                schema: "public",
                table: "CustomerAdress",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdress_IdCustomer",
                schema: "public",
                table: "CustomerAdress",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_inventories_IdProduct",
                schema: "public",
                table: "inventories",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_inventories_ProductId1",
                schema: "public",
                table: "inventories",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "public",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                schema: "public",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCompany",
                schema: "public",
                table: "Products",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_IdProduct",
                schema: "public",
                table: "SaleProduct",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_IdSale",
                schema: "public",
                table: "SaleProduct",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId1",
                schema: "public",
                table: "SaleProduct",
                column: "SaleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdCustomer",
                schema: "public",
                table: "Sales",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Taxs_IdCategory",
                schema: "public",
                table: "Taxs",
                column: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesAdresss",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerAdress",
                schema: "public");

            migrationBuilder.DropTable(
                name: "inventories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SaleProduct",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Taxs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "public");
        }
    }
}
