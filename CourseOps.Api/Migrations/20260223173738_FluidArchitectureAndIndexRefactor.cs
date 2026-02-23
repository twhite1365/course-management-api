using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseOps.Api.Migrations
{
    /// <inheritdoc />
    public partial class FluidArchitectureAndIndexRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructor",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gender",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Gender__4E24E9F794CF8B38",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Enrollme__C8EE2063A998AA40",
                table: "EnrollmentStatus");

            migrationBuilder.DropIndex(
                name: "UQ__Enrollme__737584F653038364",
                table: "EnrollmentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Enrollme__7F68771BC3F30333",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_CourseInstructor_CourseId",
                table: "CourseInstructor");

            migrationBuilder.RenameIndex(
                name: "UQ__Student__A9D10534BB0BBA7E",
                table: "Student",
                newName: "UX_Student_Email");

            migrationBuilder.RenameColumn(
                name: "RowVarsion",
                table: "Instructor",
                newName: "RowVersion");

            migrationBuilder.RenameIndex(
                name: "UQ__Gender__737584F6BC29FD6B",
                table: "Gender",
                newName: "UX_Gender_Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Student",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getutcdate())");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Instructor",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Instructor",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getutcdate())");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EnrollmentStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "statusId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "CourseInstructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseInstructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Course",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getutcdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrollmentStatus",
                table: "EnrollmentStatus",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructor",
                table: "CourseInstructor",
                columns: new[] { "CourseId", "InstructorId" });

            migrationBuilder.CreateIndex(
                name: "UX_EnrollmentStatus_Name",
                table: "EnrollmentStatus",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_CourseId",
                table: "CourseInstructor",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructor_InstructorId",
                table: "CourseInstructor",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_EnrollmentStatus_statusId",
                table: "Enrollment",
                column: "statusId",
                principalTable: "EnrollmentStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_CourseId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructor_InstructorId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_EnrollmentStatus_statusId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrollmentStatus",
                table: "EnrollmentStatus");

            migrationBuilder.DropIndex(
                name: "UX_EnrollmentStatus_Name",
                table: "EnrollmentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructor",
                table: "CourseInstructor");

            migrationBuilder.RenameIndex(
                name: "UX_Student_Email",
                table: "Student",
                newName: "UQ__Student__A9D10534BB0BBA7E");

            migrationBuilder.RenameColumn(
                name: "RowVersion",
                table: "Instructor",
                newName: "RowVarsion");

            migrationBuilder.RenameIndex(
                name: "UX_Gender_Name",
                table: "Gender",
                newName: "UQ__Gender__737584F6BC29FD6B");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Instructor",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Instructor",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EnrollmentStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "statusId",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "CourseInstructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseInstructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Gender__4E24E9F794CF8B38",
                table: "Gender",
                column: "GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Enrollme__C8EE2063A998AA40",
                table: "EnrollmentStatus",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Enrollme__7F68771BC3F30333",
                table: "Enrollment",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "UQ__Enrollme__737584F653038364",
                table: "EnrollmentStatus",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_CourseId",
                table: "CourseInstructor",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course",
                table: "CourseInstructor",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructor",
                table: "CourseInstructor",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Id",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusId",
                table: "Enrollment",
                column: "statusId",
                principalTable: "EnrollmentStatus",
                principalColumn: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Id",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gender",
                table: "Student",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId");
        }
    }
}
