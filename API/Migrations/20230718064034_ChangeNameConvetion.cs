using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ChangeNameConvetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsRoles",
                table: "AccountsRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "tb_m_universities");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "tb_m_rooms");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "tb_m_employees");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "tb_m_educations");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "tb_tr_bookings");

            migrationBuilder.RenameTable(
                name: "AccountsRoles",
                newName: "tb_tr_account_roles");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "tb_m_accounts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_universities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "tb_m_universities",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_universities",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_universities",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_universities",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "tb_m_rooms",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "tb_m_rooms",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_rooms",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_rooms",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_rooms",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_roles",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Nik",
                table: "tb_m_employees",
                newName: "nik");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "tb_m_employees",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_m_employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_employees",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "tb_m_employees",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "tb_m_employees",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "HiringDate",
                table: "tb_m_employees",
                newName: "hiring_date");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "tb_m_employees",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "tb_m_employees",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_employees",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_employees",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Nik_Email_PhoneNumber",
                table: "tb_m_employees",
                newName: "IX_tb_m_employees_nik_email_phone_number");

            migrationBuilder.RenameColumn(
                name: "Major",
                table: "tb_m_educations",
                newName: "major");

            migrationBuilder.RenameColumn(
                name: "Gpa",
                table: "tb_m_educations",
                newName: "gpa");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "tb_m_educations",
                newName: "degree");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_educations",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UniversityGuid",
                table: "tb_m_educations",
                newName: "university_guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_educations",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_educations",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tb_tr_bookings",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "tb_tr_bookings",
                newName: "remarks");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_tr_bookings",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "tb_tr_bookings",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "RoomGuid",
                table: "tb_tr_bookings",
                newName: "room_guid");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "tb_tr_bookings",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "EmployeeGuid",
                table: "tb_tr_bookings",
                newName: "employee_guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_tr_bookings",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_tr_bookings",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_tr_account_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "RoleGuid",
                table: "tb_tr_account_roles",
                newName: "role_guid");

            migrationBuilder.RenameColumn(
                name: "AccountGuid",
                table: "tb_tr_account_roles",
                newName: "account_guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_tr_account_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_tr_account_roles",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tb_m_accounts",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "tb_m_accounts",
                newName: "otp");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_accounts",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_accounts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "ExpiredTime",
                table: "tb_m_accounts",
                newName: "expired_date");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "tb_m_accounts",
                newName: "created_date");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tb_m_universities",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "tb_m_universities",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tb_m_rooms",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tb_m_roles",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nik",
                table: "tb_m_employees",
                type: "nchar(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "tb_m_employees",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "major",
                table: "tb_m_educations",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "degree",
                table: "tb_m_educations",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_account_roles",
                table: "tb_tr_account_roles",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_account_roles",
                table: "tb_tr_account_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "tb_tr_bookings",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "tb_tr_account_roles",
                newName: "AccountsRoles");

            migrationBuilder.RenameTable(
                name: "tb_m_universities",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "tb_m_rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tb_m_employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "tb_m_educations",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Bookings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "Bookings",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Bookings",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "room_guid",
                table: "Bookings",
                newName: "RoomGuid");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Bookings",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "employee_guid",
                table: "Bookings",
                newName: "EmployeeGuid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Bookings",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Bookings",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "AccountsRoles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "role_guid",
                table: "AccountsRoles",
                newName: "RoleGuid");

            migrationBuilder.RenameColumn(
                name: "account_guid",
                table: "AccountsRoles",
                newName: "AccountGuid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "AccountsRoles",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "AccountsRoles",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Universities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Universities",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Universities",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Universities",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Universities",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "Rooms",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Rooms",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Rooms",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Rooms",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Rooms",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Roles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Roles",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Roles",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "nik",
                table: "Employees",
                newName: "Nik");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Employees",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Employees",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Employees",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "hiring_date",
                table: "Employees",
                newName: "HiringDate");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Employees",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Employees",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Employees",
                newName: "CreatedTime");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_employees_nik_email_phone_number",
                table: "Employees",
                newName: "IX_Employees_Nik_Email_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "major",
                table: "Educations",
                newName: "Major");

            migrationBuilder.RenameColumn(
                name: "gpa",
                table: "Educations",
                newName: "Gpa");

            migrationBuilder.RenameColumn(
                name: "degree",
                table: "Educations",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Educations",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "university_guid",
                table: "Educations",
                newName: "UniversityGuid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Educations",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Educations",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "otp",
                table: "Accounts",
                newName: "Otp");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Accounts",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Accounts",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "expired_date",
                table: "Accounts",
                newName: "ExpiredTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Accounts",
                newName: "CreatedTime");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Nik",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsRoles",
                table: "AccountsRoles",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Guid");
        }
    }
}
