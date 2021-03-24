using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagementSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(maxLength: 100, nullable: true),
                    DivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_BasicInfo",
                columns: table => new
                {
                    EmpBasicInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    EmpID = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DesignationID = table.Column<int>(nullable: false),
                    IsClassTeacher = table.Column<bool>(nullable: false),
                    TypeID = table.Column<int>(nullable: false),
                    SectionID = table.Column<int>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    ShiftID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    NationalID = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    PresentPost = table.Column<string>(nullable: true),
                    PresentThana = table.Column<string>(nullable: true),
                    PresentDistrict = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    PermanentPost = table.Column<string>(nullable: true),
                    PermanentThana = table.Column<string>(nullable: true),
                    PermanentDistrict = table.Column<string>(nullable: true),
                    InstituteAccount = table.Column<string>(nullable: true),
                    IsGovtSalaryActive = table.Column<bool>(nullable: false),
                    GovtSalaryGrade = table.Column<int>(nullable: false),
                    GovtAccount = table.Column<string>(nullable: true),
                    DisOrder = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SMSNotificationNo = table.Column<string>(nullable: true),
                    DeviceUserID = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    IsPermanent = table.Column<bool>(nullable: false),
                    ProbationPeriodEndDate = table.Column<DateTime>(nullable: true),
                    ConfirmationDate = table.Column<DateTime>(nullable: true),
                    Accountname = table.Column<string>(nullable: true),
                    JoiningSalary = table.Column<string>(nullable: true),
                    ConfirmationSalary = table.Column<string>(nullable: true),
                    CurrentSalary = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    SalaryACNo = table.Column<string>(nullable: true),
                    MPOIndexNo = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    PPExpireDate = table.Column<DateTime>(nullable: true),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyContactRelation = table.Column<string>(nullable: true),
                    EmergencyContactAddress = table.Column<string>(nullable: true),
                    EmergencyTandTNo = table.Column<string>(nullable: true),
                    EmergencyContactNo = table.Column<string>(nullable: true),
                    ContactOfficeEmail = table.Column<string>(nullable: true),
                    ContactOtherEmail = table.Column<string>(nullable: true),
                    ContactHomeNo = table.Column<string>(nullable: true),
                    ContactOfficeNo = table.Column<string>(nullable: true),
                    DPSAcccountNo = table.Column<string>(nullable: true),
                    eTIN = table.Column<string>(nullable: true),
                    InstituteGrade = table.Column<string>(nullable: true),
                    PFAccountNo = table.Column<string>(nullable: true),
                    ReportingPersonID = table.Column<int>(nullable: false),
                    ReportOrderNo = table.Column<int>(nullable: false),
                    SalaryGradeID = table.Column<int>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    RetirementDate = table.Column<DateTime>(nullable: true),
                    BirthRegNo = table.Column<string>(nullable: true),
                    DrivingLicenseNo = table.Column<string>(nullable: true),
                    OfficePhoneNo = table.Column<string>(nullable: true),
                    HomePhoneNo = table.Column<string>(nullable: true),
                    SpouseName = table.Column<string>(nullable: true),
                    SpouseMobile = table.Column<string>(nullable: true),
                    Child = table.Column<string>(nullable: true),
                    BirthCertificate = table.Column<string>(nullable: true),
                    DrawbackMedicine = table.Column<string>(nullable: true),
                    PFACNo = table.Column<string>(nullable: true),
                    PFBankName = table.Column<string>(nullable: true),
                    PFBankBranch = table.Column<string>(nullable: true),
                    WelfareACNo = table.Column<string>(nullable: true),
                    MembershipNo = table.Column<string>(nullable: true),
                    TINNo = table.Column<string>(nullable: true),
                    LeaveTypeId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    IsResignationApplied = table.Column<bool>(nullable: true),
                    ServeDate = table.Column<DateTime>(nullable: true),
                    SalaryPaymentMode = table.Column<string>(nullable: true),
                    SkypeUsername = table.Column<string>(nullable: true),
                    WhatsAppNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_BasicInfo", x => x.EmpBasicInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryIsTeacher = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    DisOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Designation",
                columns: table => new
                {
                    DesignationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    DesignationName = table.Column<string>(nullable: true),
                    CategoryID = table.Column<string>(nullable: true),
                    DesignationOrder = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Designation", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationName = table.Column<string>(maxLength: 100, nullable: false),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostOffice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOfficeName = table.Column<string>(maxLength: 100, nullable: false),
                    PoliceStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Like = table.Column<int>(nullable: false),
                    Dislike = table.Column<int>(nullable: false),
                    AddBy = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_Issue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    IssueTypeId = table.Column<int>(nullable: true),
                    SprintId = table.Column<int>(nullable: true),
                    AssigneeId = table.Column<int>(nullable: true),
                    ReporterId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    AlertRule = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    EstimatedTime = table.Column<int>(nullable: false),
                    EstimatedType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_IssueAttachment",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_IssueAttachment", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "Task_IssueHistory",
                columns: table => new
                {
                    HistoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IssueId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    SprinttId = table.Column<int>(nullable: true),
                    PreviousId = table.Column<int>(nullable: true),
                    PresentId = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_IssueHistory", x => x.HistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Task_IssueStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_IssueStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_IssueType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    IssueTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_IssueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_IssueWebLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_IssueWebLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    IsSupport = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_ProjectUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_ProjectUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task_Sprint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddBy = table.Column<string>(maxLength: 128, nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    SprintTitle = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<int>(nullable: false),
                    Goal = table.Column<string>(nullable: true),
                    PersonId = table.Column<string>(nullable: true),
                    IsStart = table.Column<bool>(nullable: false),
                    IsSupport = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Sprint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Country");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Emp_BasicInfo");

            migrationBuilder.DropTable(
                name: "Emp_Category");

            migrationBuilder.DropTable(
                name: "Emp_Department");

            migrationBuilder.DropTable(
                name: "Emp_Designation");

            migrationBuilder.DropTable(
                name: "PoliceStation");

            migrationBuilder.DropTable(
                name: "PostOffice");

            migrationBuilder.DropTable(
                name: "Task_Client");

            migrationBuilder.DropTable(
                name: "Task_Comments");

            migrationBuilder.DropTable(
                name: "Task_Issue");

            migrationBuilder.DropTable(
                name: "Task_IssueAttachment");

            migrationBuilder.DropTable(
                name: "Task_IssueHistory");

            migrationBuilder.DropTable(
                name: "Task_IssueStatus");

            migrationBuilder.DropTable(
                name: "Task_IssueType");

            migrationBuilder.DropTable(
                name: "Task_IssueWebLink");

            migrationBuilder.DropTable(
                name: "Task_Project");

            migrationBuilder.DropTable(
                name: "Task_ProjectUsers");

            migrationBuilder.DropTable(
                name: "Task_Sprint");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
