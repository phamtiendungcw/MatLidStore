﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLS.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MATLID_AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_AspNetRoleClaims_MATLID_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "MATLID_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Products_MATLID_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MATLID_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_Products_MATLID_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "MATLID_Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Addresses_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorUserId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Articles_MATLID_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "MATLID_Tags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MATLID_Articles_MATLID_Users_AuthorUserId",
                        column: x => x.AuthorUserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_AspNetUserClaims_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_MATLID_AspNetUserLogins_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_MATLID_AspNetUserTokens_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Notifications_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Orders_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ShoppingCarts_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_MATLID_UserRoles_MATLID_AspNetUserRoles_UserId_RoleId",
                        columns: x => new { x.UserId, x.RoleId },
                        principalTable: "MATLID_AspNetUserRoles",
                        principalColumns: new[] { "UserId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_MATLID_UserRoles_MATLID_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "MATLID_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MATLID_UserRoles_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_WishLists_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorHexCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductColors_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductImages_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ProductOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ProductOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductOptions_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductReviews_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductReviews_MATLID_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ProductTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductTags_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_ProductTags_MATLID_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "MATLID_Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Supplies_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_Supplies_MATLID_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "MATLID_Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    CommenterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Comments_MATLID_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "MATLID_Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MATLID_Comments_MATLID_Users_CommenterId",
                        column: x => x.CommenterId,
                        principalTable: "MATLID_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_OrderDetails_MATLID_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "MATLID_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_OrderDetails_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Payments_MATLID_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "MATLID_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_Shipments_MATLID_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "MATLID_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_ShoppingCartItems_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_ShoppingCartItems_MATLID_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "MATLID_ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MATLID_WishListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WishListId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATLID_WishListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MATLID_WishListItems_MATLID_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MATLID_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATLID_WishListItems_MATLID_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "MATLID_WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MATLID_AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "MATLID_Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1bc3b83b-32c5-40e1-844b-b446b817d9cc", "Administrator", "ADMINISTRATOR" },
                    { 2, "34bbfea0-6f2c-41b0-bc72-d87c4d61e344", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "MATLID_Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "33697c3d-8096-441e-aee8-e575e434725c", "admin@matlidstore.com", true, "System", false, "Admin", false, null, "ADMIN@MATLIDSTORE.COM", "ADMIN", "AQAAAAEAACcQAAAAEDtq7OeT3Aw4bE46ORL+VMaUdYmJXMmoah9qHB1a4W3i8scI/+elonFMbcuj+yr3IQ==", null, null, false, null, false, "admin" },
                    { 2, 0, "8f4c70fe-dd8d-480f-b2b5-94164650db10", "user@matlidstore.com", true, "System", false, "User", false, null, "USER@MATLIDSTORE.COM", "USER", "AQAAAAEAACcQAAAAEKYPRcaOKZAH1TbkDivcLJAKkCOSNkW+qdPKfX4YOW0+u4OyCmuYxlqIyXW6H9I8Fw==", null, null, false, null, false, "user" }
                });

            migrationBuilder.InsertData(
                table: "MATLID_UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MATLID_UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Addresses_UserId",
                table: "MATLID_Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Articles_AuthorUserId",
                table: "MATLID_Articles",
                column: "AuthorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Articles_TagId",
                table: "MATLID_Articles",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_AspNetRoleClaims_RoleId",
                table: "MATLID_AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_AspNetUserClaims_UserId",
                table: "MATLID_AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_AspNetUserLogins_UserId",
                table: "MATLID_AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Comments_ArticleId",
                table: "MATLID_Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Comments_CommenterId",
                table: "MATLID_Comments",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Notifications_UserId",
                table: "MATLID_Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_OrderDetails_OrderId",
                table: "MATLID_OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_OrderDetails_ProductId",
                table: "MATLID_OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Orders_UserId",
                table: "MATLID_Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Payments_OrderId",
                table: "MATLID_Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductColors_ProductId",
                table: "MATLID_ProductColors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductImages_ProductId",
                table: "MATLID_ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductOptions_ProductId",
                table: "MATLID_ProductOptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductReviews_ProductId",
                table: "MATLID_ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductReviews_UserId",
                table: "MATLID_ProductReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Products_CategoryId",
                table: "MATLID_Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Products_SupplierId",
                table: "MATLID_Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductTags_ProductId",
                table: "MATLID_ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ProductTags_TagId",
                table: "MATLID_ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "MATLID_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Shipments_OrderId",
                table: "MATLID_Shipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ShoppingCartItems_ProductId",
                table: "MATLID_ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ShoppingCartItems_ShoppingCartId",
                table: "MATLID_ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_ShoppingCarts_UserId",
                table: "MATLID_ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Supplies_ProductId",
                table: "MATLID_Supplies",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_Supplies_SupplierId",
                table: "MATLID_Supplies",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_UserRoles_RoleId",
                table: "MATLID_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "MATLID_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "MATLID_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_WishListItems_ProductId",
                table: "MATLID_WishListItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_WishListItems_WishListId",
                table: "MATLID_WishListItems",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_MATLID_WishLists_UserId",
                table: "MATLID_WishLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MATLID_Addresses");

            migrationBuilder.DropTable(
                name: "MATLID_AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "MATLID_AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "MATLID_AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "MATLID_AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MATLID_Comments");

            migrationBuilder.DropTable(
                name: "MATLID_Discounts");

            migrationBuilder.DropTable(
                name: "MATLID_Notifications");

            migrationBuilder.DropTable(
                name: "MATLID_OrderDetails");

            migrationBuilder.DropTable(
                name: "MATLID_Payments");

            migrationBuilder.DropTable(
                name: "MATLID_ProductColors");

            migrationBuilder.DropTable(
                name: "MATLID_ProductImages");

            migrationBuilder.DropTable(
                name: "MATLID_ProductOptions");

            migrationBuilder.DropTable(
                name: "MATLID_ProductReviews");

            migrationBuilder.DropTable(
                name: "MATLID_ProductTags");

            migrationBuilder.DropTable(
                name: "MATLID_Shipments");

            migrationBuilder.DropTable(
                name: "MATLID_ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "MATLID_Supplies");

            migrationBuilder.DropTable(
                name: "MATLID_UserRoles");

            migrationBuilder.DropTable(
                name: "MATLID_WishListItems");

            migrationBuilder.DropTable(
                name: "MATLID_Articles");

            migrationBuilder.DropTable(
                name: "MATLID_Orders");

            migrationBuilder.DropTable(
                name: "MATLID_ShoppingCarts");

            migrationBuilder.DropTable(
                name: "MATLID_AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "MATLID_Roles");

            migrationBuilder.DropTable(
                name: "MATLID_Products");

            migrationBuilder.DropTable(
                name: "MATLID_WishLists");

            migrationBuilder.DropTable(
                name: "MATLID_Tags");

            migrationBuilder.DropTable(
                name: "MATLID_Categories");

            migrationBuilder.DropTable(
                name: "MATLID_Suppliers");

            migrationBuilder.DropTable(
                name: "MATLID_Users");
        }
    }
}
