using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ramand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetUsersStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetUsersProcedure
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT Username, Email
                                        FROM AspNetUsers;
                                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetUsersProcedure");
        }
    }
}
