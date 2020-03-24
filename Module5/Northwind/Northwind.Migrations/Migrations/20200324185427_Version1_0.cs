using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Migrations.Migrations
{
    public partial class Version1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                columns: table => new
                {
                    CustomerTypeID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CustomerDesc = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDemographics", x => x.CustomerTypeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: true),
                    TitleOfCourtesy = table.Column<string>(maxLength: 25, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    HomePhone = table.Column<string>(maxLength: 24, nullable: true),
                    Extension = table.Column<string>(maxLength: 4, nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    ReportsTo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false),
                    RegionDescription = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    Phone = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    HomePage = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                columns: table => new
                {
                    CustomerID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: false),
                    CustomerTypeID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerDemo", x => new { x.CustomerID, x.CustomerTypeID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_Customers",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false),
                    TerritoryDescription = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    RegionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.TerritoryID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Territories_Region",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: true),
                    EmployeeID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipVia = table.Column<int>(nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    ShipName = table.Column<string>(maxLength: 40, nullable: true),
                    ShipAddress = table.Column<string>(maxLength: 60, nullable: true),
                    ShipCity = table.Column<string>(maxLength: 15, nullable: true),
                    ShipRegion = table.Column<string>(maxLength: 15, nullable: true),
                    ShipPostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    ShipCountry = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 40, nullable: false),
                    SupplierID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    QuantityPerUnit = table.Column<string>(maxLength: 20, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    UnitsInStock = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    UnitsOnOrder = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    ReorderLevel = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    Discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTerritories", x => new { x.EmployeeID, x.TerritoryID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Territories",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<short>(nullable: false, defaultValueSql: "((1))"),
                    Discount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Details_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Beverages", "Soft drinks, coffees, teas, beers, and ales" },
                    { 2, "Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings" },
                    { 3, "Confections", "Desserts, candies, and sweet breads" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "CompanyName", "ContactName", "ContactTitle", "Country", "Fax", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { "ALFKI", "Obere Str. 57", "Berlin", "Alfreds Futterkiste", "Maria Anders", "Sales Representative", "Germany", "030-0076545", "030-0074321", "12209", null },
                    { "ANATR", "Avda. de la Constitucion 2222", "Mexico D.F.", "Ana Trujillo Emparedados y helados", "Ana Trujillo", "Owner", "Mexico", "(5) 555-3745", "(5) 555-4729", "05021", null },
                    { "ANTON", "Mataderos  2312", "Mexico D.F.", "Antonio Moreno Taqueria", "Antonio Moreno", "Owner", "Mexico", null, "(5) 555-3932", "05023", null },
                    { "AROUT", "120 Hanover Sq.", "London", "Around the Horn", "Thomas Hardy", "Sales Representative", "UK", "(171) 555-6750", "(171) 555-7788", "WA1 1DP", null },
                    { "BERGS", "Berguvsvagen  8", "Lulea", "Berglunds snabbkop", "Christina Berglund", "Order Administrator", "Sweden", "0921-12 34 67", "0921-12 34 65", "S-958 22", null }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "RegionID", "RegionDescription" },
                values: new object[,]
                {
                    { 4, "Southern" },
                    { 3, "Northern" },
                    { 2, "Western" },
                    { 1, "Eastern" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "BirthDate", "City", "Country", "Extension", "FirstName", "HireDate", "HomePhone", "LastName", "Notes", "PostalCode", "Region", "ReportsTo", "Title", "TitleOfCourtesy" },
                values: new object[,]
                {
                    { 1, "507 - 20th Ave. E.Apt. 2A", null, "Seattle", "USA", "5467", "Nancy", null, "(206) 555-9857", "Davolio", "Education includes a BA in psychology from Colorado State University in 1970.  She also completed The Art of the Cold Call.  Nancy is a member of Toastmasters International.", "98122", "WA", 2, "Sales Representative", "Ms." },
                    { 2, "908 W. Capital Way", null, "Tacoma", "USA", "3457", "Andrew", null, "(206) 555-9482", "Fuller", "Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.", "98401", "WA", null, "Vice President, Sales", "Dr." },
                    { 3, "722 Moss Bay Blvd.", null, "Kirkland", "USA", "3355", "Janet", null, "(206) 555-3412", "Leverling", "Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.", "98033", "WA", 2, "Sales Representative", "Ms." }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Address", "City", "CompanyName", "ContactName", "ContactTitle", "Country", "Fax", "HomePage", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "49 Gilbert St.", "London", "Exotic Liquids", "Charlotte Cooper", "Purchasing Manager", "UK", null, null, "(171) 555-2222", "EC1 4SD", null },
                    { 2, "P.O. Box 78934", "New Orleans", "New Orleans Cajun Delights", "Shelley Burke", "Order Administrator", "USA", null, "#CAJUN.HTM#", "(100) 555-4822", "70117", "LA" },
                    { 3, "707 Oxford Rd.", "Ann Arbor", "Grandma Kelly's Homestead", "Regina Murphy", "Sales Representative", "USA", "(313) 555-3349", null, "(313) 555-5735", "48104", "MI" },
                    { 4, "9-8 Sekimai Musashino-shi", "Tokyo", "Tokyo Traders", "Yoshi Nagase", "Marketing Manager", "Japan", null, null, "(03) 3555-5011", "100", null },
                    { 5, "Calle del Rosal 4", "Oviedo", "Cooperativa de Quesos 'Las Cabras'", "Antonio del Valle Saavedra", "Export Administrator", "Spain", null, null, "(98) 598 76 54", "33007", "Asturias" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Discontinued", "ProductName", "QuantityPerUnit", "ReorderLevel", "SupplierID", "UnitPrice", "UnitsInStock", "UnitsOnOrder" },
                values: new object[,]
                {
                    { 7, 2, false, "Louisiana Fiery Hot Pepper Sauce", "32 - 8 oz bottles", (short)0, 2, 21.05m, (short)76, (short)0 },
                    { 5, 2, true, "Chef Anton's Gumbo Mix", "36 boxes", (short)0, 2, 21.35m, (short)0, (short)0 },
                    { 4, 2, false, "Chef Anton's Cajun Seasoning", "48 - 6 oz jars", (short)0, 2, 22m, (short)53, (short)0 },
                    { 3, 2, false, "Aniseed Syrup", "", (short)25, 1, 10m, (short)13, (short)70 },
                    { 2, 1, false, "Chang", "24 - 12 oz bottles", (short)25, 1, 19m, (short)17, (short)40 },
                    { 1, 1, false, "Chai", "10 boxes x 20 bags", (short)10, 1, 18m, (short)39, (short)0 },
                    { 8, 2, false, "Louisiana Hot Spiced Okra", "24 - 8 oz jars", (short)20, 2, 17m, (short)4, (short)100 },
                    { 6, 2, false, "Northwoods Cranberry Sauce", "12 - 12 oz jars", (short)0, 3, 40m, (short)6, (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperID", "CompanyName", "Phone" },
                values: new object[,]
                {
                    { 1, "Speedy Express", "(503) 555-9831"},
                    { 2, "United Package", "(503) 555-3199"},
                    { 3, "Federal Shipping", "(503) 555-9931"}
                });

            migrationBuilder.InsertData(
                table: "Territories",
                columns: new[] { "TerritoryID", "RegionID", "TerritoryDescription" },
                values: new object[,]
                {
                    { "48304", 3, "Bloomfield Hills" },
                    { "20852", 1, "Rockville" },
                    { "27403", 1, "Greensboro" },
                    { "27511", 1, "Cary" },
                    { "40222", 1, "Louisville" },
                    { "44122", 3, "Beachwood" },
                    { "45839", 3, "Findlay" },
                    { "48084", 3, "Troy" },
                    { "33607", 4, "Tampa" },
                    { "31406", 4, "Savannah" },
                    { "30346", 4, "Atlanta" },
                    { "29202", 4, "Columbia" },
                    { "48075", 3, "Southfield" },
                    { "55113", 3, "Roseville" },
                    { "53404", 3, "Racine" },
                    { "32859", 4, "Orlando" },
                    { "55439", 3, "Minneapolis" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTerritories",
                columns: new[] { "EmployeeID", "TerritoryID" },
                values: new object[,]
                {
                    { 2, "40222" },
                    { 2, "31406" },
                    { 2, "30346" },
                    { 2, "29202" },
                    { 3, "55439" },
                    { 3, "55113" },
                    { 3, "53404" },
                    { 3, "48304" },
                    { 3, "48084" },
                    { 3, "48075" },
                    { 3, "45839" },
                    { 2, "32859" },
                    { 2, "33607" },
                    { 1, "27403" },
                    { 1, "20852" },
                    { 2, "27511" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "EmployeeID", "Freight", "OrderDate", "RequiredDate", "ShipAddress", "ShipCity", "ShipCountry", "ShipName", "ShipPostalCode", "ShipRegion", "ShipVia", "ShippedDate" },
                values: new object[,]
                {
                    { 10856, "ANTON", 3, 58.43m, null, null, "Mataderos  2312", "México D.F.", "Mexico", "Antonio Moreno Taquería", "05023", null, 2, null },
                    { 10682, "ANTON", 3, 36.13m, null, null, "Mataderos  2312", "México D.F.", "Mexico", "Antonio Moreno Taquería", "05023", null, 2, null },
                    { 10365, "ANTON", 3, 22.00m, null, null, "Mataderos  2312", "México D.F.", "Mexico", "Antonio Moreno Taquería", "05023", null, 2, null },
                    { 10759, "ANATR", 3, 11.99m, null, null, "Avda. de la Constitución 2222", "México D.F.", "Mexico", "Ana Trujillo Emparedados y helados", "05021", null, 3, null },
                    { 10625, "ANATR", 3, 43.90m, null, null, "Avda. de la Constitución 2222", "México D.F.", "Mexico", "Ana Trujillo Emparedados y helados", "05021", null, 1, null },
                    { 11011, "ALFKI", 3, 1.21m, null, null, "Obere Str. 57", "Berlin", "Germany", "Alfred's Futterkiste", "12209", null, 1, null },
                    { 10677, "ANTON", 1, 4.03m, null, null, "Mataderos  2312", "México D.F.", "Mexico", "Antonio Moreno Taquería", "05023", null, 3, null },
                    { 10952, "ALFKI", 1, 40.42m, null, null, "Obere Str. 57", "Berlin", "Germany", "Alfred's Futterkiste", "12209", null, 1, null },
                    { 10835, "ALFKI", 1, 69.53m, null, null, "Obere Str. 57", "Berlin", "Germany", "Alfred's Futterkiste", "12209", null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Order Details",
                columns: new[] { "OrderID", "ProductID", "Discount", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 10835, 1, 0f, (short)15, 55m },
                    { 10835, 2, 0f, (short)2, 13m },
                    { 10952, 6, 0f, (short)16, 25m },
                    { 10952, 7, 0f, (short)2, 45.60m },
                    { 10677, 6, 0.15f, (short)30, 31.23m },
                    { 10677, 8, 0.15f, (short)8, 2.50m },
                    { 11011, 8, 0.05f, (short)40, 11.25m },
                    { 11011, 3, 0f, (short)20, 21.50m },
                    { 10625, 1, 0f, (short)3, 23.25m },
                    { 10625, 2, 0f, (short)5, 14m },
                    { 10625, 5, 0f, (short)10, 4m },
                    { 10759, 2, 0f, (short)10, 32m },
                    { 10365, 7, 0f, (short)24, 16.80m },
                    { 10682, 3, 0f, (short)40, 2.50m },
                    { 10856, 2, 0f, (short)20, 19m },
                    { 10856, 4, 0f, (short)20, 14m }
                });

            migrationBuilder.CreateIndex(
                name: "CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeID",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "Region",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                table: "EmployeeTerritories",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "OrdersOrder_Details",
                table: "Order Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "ProductsOrder_Details",
                table: "Order Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "CustomersOrders",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "EmployeesOrders",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "ShipPostalCode",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "ShippersOrders",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "ShippedDate",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "SuppliersProducts",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Suppliers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionID",
                table: "Territories",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "CustomerDemographics");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
