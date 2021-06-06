using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
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
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingPackages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingPackageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPackages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomStatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DutyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Managers_Duties_DutyId",
                        column: x => x.DutyId,
                        principalTable: "Duties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DutyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workers_Duties_DutyId",
                        column: x => x.DutyId,
                        principalTable: "Duties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<short>(type: "smallint", nullable: false),
                    FloorNumber = table.Column<short>(type: "smallint", nullable: false),
                    SingleBadCount = table.Column<short>(type: "smallint", nullable: false),
                    DoubleBadCount = table.Column<short>(type: "smallint", nullable: true),
                    RoomDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoomFeatures = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomStatuses_RoomStatusId",
                        column: x => x.RoomStatusId,
                        principalTable: "RoomStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomTypeImages_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollForManagers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollForManagers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayrollForManagers_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollForWorkers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    HourlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyWorkingHours = table.Column<short>(type: "smallint", nullable: false),
                    TotalWorkingDaysPerMonth = table.Column<short>(type: "smallint", nullable: false),
                    Overtime = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollForWorkers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayrollForWorkers_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BookingFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoOfGuests = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    BookingPackageId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingPackages_BookingPackageId",
                        column: x => x.BookingPackageId,
                        principalTable: "BookingPackages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Guests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookingPackages",
                columns: new[] { "ID", "BookingPackageName" },
                values: new object[,]
                {
                    { 1, "Tam Pansiyon" },
                    { 2, "Her Şey Dahil" }
                });

            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "ID", "Description", "DutyName" },
                values: new object[,]
                {
                    { 1, "Resepsiyonda görevli personel", "Resepsiyon Görevlisi" },
                    { 2, "Temizlikten sorumlu personel", "Temizlik Görevlisi" },
                    { 3, "Mutfak Personeli", "Aşçı" },
                    { 4, "Restaurant çalışanı", "Garson" },
                    { 5, "Elektrik işleri sorumlusu personel", "Elektrikçi" },
                    { 6, "Bilgi işlem personeli", "Bilgi İşlem Sorumlusu" },
                    { 7, "Yönetici", "Yönetici" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "ID", "PaymentTypeName" },
                values: new object[,]
                {
                    { 3, "Nakit" },
                    { 2, "Banka Kartı" },
                    { 1, "Kredi Kartı" }
                });

            migrationBuilder.InsertData(
                table: "RoomStatuses",
                columns: new[] { "ID", "RoomStatusName" },
                values: new object[,]
                {
                    { 1, "Müsait" },
                    { 2, "Dolu" },
                    { 3, "Temizlenecek" },
                    { 4, "Tadilatta" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "ID", "BasePrice", "RoomTypeName" },
                values: new object[,]
                {
                    { 1, 200m, "Tek Kişilik Oda" },
                    { 2, 300m, "İki Kişilik Oda" },
                    { 3, 350m, "Üç Kişilik Oda" },
                    { 4, 425m, "Dört Kişilik Oda" },
                    { 5, 500m, "Kral Dairesi" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "DoubleBadCount", "FloorNumber", "RoomDescription", "RoomFeatures", "RoomNumber", "RoomStatusId", "RoomTypeId", "SingleBadCount" },
                values: new object[,]
                {
                    { 1, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)110, 1, 1, (short)1 },
                    { 15, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)134, 1, 3, (short)3 },
                    { 14, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)133, 1, 3, (short)3 },
                    { 13, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)132, 1, 3, (short)3 },
                    { 12, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)131, 1, 3, (short)3 },
                    { 11, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)130, 1, 3, (short)3 },
                    { 70, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)429, 1, 2, (short)0 },
                    { 69, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)428, 1, 2, (short)0 },
                    { 68, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)427, 1, 2, (short)0 },
                    { 67, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)426, 1, 2, (short)0 },
                    { 66, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)425, 1, 2, (short)0 },
                    { 65, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)424, 1, 2, (short)0 },
                    { 64, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)423, 1, 2, (short)0 },
                    { 63, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)422, 1, 2, (short)0 },
                    { 62, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)421, 1, 2, (short)0 },
                    { 61, (short)1, (short)4, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)420, 1, 2, (short)0 },
                    { 16, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)135, 1, 3, (short)3 },
                    { 17, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)136, 1, 3, (short)3 },
                    { 18, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)137, 1, 3, (short)3 },
                    { 19, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)138, 1, 3, (short)3 },
                    { 75, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)445, 1, 4, (short)2 },
                    { 74, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)444, 1, 4, (short)2 },
                    { 73, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)443, 1, 4, (short)2 },
                    { 72, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)442, 1, 4, (short)2 },
                    { 71, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)441, 1, 4, (short)2 },
                    { 60, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)339, 1, 3, (short)1 },
                    { 59, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)338, 1, 3, (short)1 },
                    { 50, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)329, 1, 2, (short)0 },
                    { 58, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)337, 1, 3, (short)1 },
                    { 56, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)335, 1, 3, (short)1 },
                    { 55, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)334, 1, 3, (short)1 },
                    { 54, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)333, 1, 3, (short)1 },
                    { 53, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)332, 1, 3, (short)1 },
                    { 52, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)331, 1, 3, (short)1 },
                    { 51, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)330, 1, 3, (short)1 },
                    { 20, (short)0, (short)1, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)139, 1, 3, (short)3 },
                    { 57, (short)1, (short)3, "Üç kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)336, 1, 3, (short)1 },
                    { 76, (short)1, (short)4, "Dört kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)446, 1, 4, (short)2 },
                    { 49, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)328, 1, 2, (short)0 },
                    { 47, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)326, 1, 2, (short)0 },
                    { 26, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)215, 1, 1, (short)1 },
                    { 25, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)214, 1, 1, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "DoubleBadCount", "FloorNumber", "RoomDescription", "RoomFeatures", "RoomNumber", "RoomStatusId", "RoomTypeId", "SingleBadCount" },
                values: new object[,]
                {
                    { 24, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)213, 1, 1, (short)1 },
                    { 23, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)212, 1, 1, (short)1 },
                    { 22, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)211, 1, 1, (short)1 },
                    { 21, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)210, 1, 1, (short)1 },
                    { 10, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)119, 1, 1, (short)1 },
                    { 9, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)118, 1, 1, (short)1 },
                    { 8, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)117, 1, 1, (short)1 },
                    { 7, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)116, 1, 1, (short)1 },
                    { 6, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)115, 1, 1, (short)1 },
                    { 5, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)114, 1, 1, (short)1 },
                    { 4, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)113, 1, 1, (short)1 },
                    { 3, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)112, 1, 1, (short)1 },
                    { 2, (short)0, (short)1, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)111, 1, 1, (short)1 },
                    { 27, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)216, 1, 1, (short)1 },
                    { 28, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)217, 1, 1, (short)1 },
                    { 29, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)218, 1, 1, (short)1 },
                    { 30, (short)0, (short)2, "Tek kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet", (short)219, 1, 1, (short)1 },
                    { 46, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)325, 1, 2, (short)0 },
                    { 45, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)324, 1, 2, (short)0 },
                    { 44, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)323, 1, 2, (short)0 },
                    { 43, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)322, 1, 2, (short)0 },
                    { 42, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)321, 1, 2, (short)0 },
                    { 41, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)320, 1, 2, (short)0 },
                    { 40, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)229, 1, 2, (short)2 },
                    { 48, (short)1, (short)3, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)327, 1, 2, (short)0 },
                    { 39, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)228, 1, 2, (short)2 },
                    { 37, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)226, 1, 2, (short)2 },
                    { 36, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)225, 1, 2, (short)2 },
                    { 35, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)224, 1, 2, (short)2 },
                    { 34, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)223, 1, 2, (short)2 },
                    { 33, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)222, 1, 2, (short)2 },
                    { 32, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)221, 1, 2, (short)2 },
                    { 31, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)220, 1, 2, (short)2 },
                    { 38, (short)0, (short)2, "İki kişilik oda", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar", (short)227, 1, 2, (short)2 },
                    { 77, (short)2, (short)4, "Kral Dairesi", "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon", (short)500, 1, 5, (short)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingPackageId",
                table: "Bookings",
                column: "BookingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomId",
                table: "Guests",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_DutyId",
                table: "Managers",
                column: "DutyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollForManagers_ManagerId",
                table: "PayrollForManagers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollForWorkers_WorkerId",
                table: "PayrollForWorkers",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeImages_RoomTypeId",
                table: "RoomTypeImages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DutyId",
                table: "Workers",
                column: "DutyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PayrollForManagers");

            migrationBuilder.DropTable(
                name: "PayrollForWorkers");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "RoomTypeImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BookingPackages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "RoomStatuses");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
