using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigetre.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Ein = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: true),
                    ClientAddressId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Ein = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: true),
                    CompanyAddressId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    InitialWorkload = table.Column<short>(type: "SMALLINT", nullable: false),
                    PeriodicWorkload = table.Column<short>(type: "SMALLINT", nullable: false),
                    Validity = table.Column<short>(type: "SMALLINT", nullable: false),
                    Logo = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    SpecializationId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(32)", maxLength: 32, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Ssn = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: true),
                    Ic = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: true),
                    Telephone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    Signature = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(16)", maxLength: 16, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(48)", maxLength: 48, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(32)", maxLength: 32, nullable: false),
                    District = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    StreetName = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(5)", maxLength: 5, nullable: false),
                    Complement = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: true),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Companies_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPhones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPhones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPhones_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramContents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Workload = table.Column<short>(type: "SMALLINT", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramContents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    CorrectAnswer = table.Column<long>(type: "bigint", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Situation = table.Column<short>(type: "SMALLINT", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityClaim_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_IdentityUserToken_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    Ssn = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: true),
                    Registry = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Telephone = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    Signature = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    SpecializationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStudent",
                columns: table => new
                {
                    CompaniesId = table.Column<long>(type: "bigint", nullable: false),
                    StudentsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStudent", x => new { x.CompaniesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CompanyStudent_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<short>(type: "SMALLINT", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternatives_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTest",
                columns: table => new
                {
                    QuestionsId = table.Column<long>(type: "bigint", nullable: false),
                    TestsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTest", x => new { x.QuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_QuestionTest_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    TrainingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Watermark = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    Situation = table.Column<short>(type: "SMALLINT", nullable: false),
                    TrainingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceLists_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    TrainingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Watermark = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    Situation = table.Column<short>(type: "SMALLINT", nullable: false),
                    TrainingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ClientId = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTraining",
                columns: table => new
                {
                    StudentsId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTraining", x => new { x.StudentsId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_StudentTraining_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTraining_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorTraining",
                columns: table => new
                {
                    InstructorsId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorTraining", x => new { x.InstructorsId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_InstructorTraining_Instructors_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorTraining_Trainings_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientId",
                table: "Address",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_QuestionId",
                table: "Alternatives",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLists_TrainingId",
                table: "AttendanceLists",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TrainingId",
                table: "Certificates",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhones_ClientId",
                table: "CompanyPhones",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhones_CompanyId",
                table: "CompanyPhones",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStudent_StudentsId",
                table: "CompanyStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityClaim_UserId",
                table: "IdentityClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_NormalizedName",
                table: "IdentityRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_UserId",
                table: "IdentityRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_NormalizedEmail",
                table: "IdentityUser",
                column: "NormalizedEmail",
                unique: true,
                filter: "[NormalizedEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_NormalizedUserName",
                table: "IdentityUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin_UserId",
                table: "IdentityUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_SpecializationId",
                table: "Instructors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorTraining_TrainingsId",
                table: "InstructorTraining",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContents_CourseId",
                table: "ProgramContents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTest_TestsId",
                table: "QuestionTest",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTraining_TrainingsId",
                table: "StudentTraining",
                column: "TrainingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CourseId",
                table: "Trainings",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.DropTable(
                name: "AttendanceLists");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CompanyPhones");

            migrationBuilder.DropTable(
                name: "CompanyStudent");

            migrationBuilder.DropTable(
                name: "IdentityClaim");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "IdentityUserToken");

            migrationBuilder.DropTable(
                name: "InstructorTraining");

            migrationBuilder.DropTable(
                name: "ProgramContents");

            migrationBuilder.DropTable(
                name: "QuestionTest");

            migrationBuilder.DropTable(
                name: "StudentTraining");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
