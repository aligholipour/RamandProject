using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ramand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetFirstUserStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetFirstUser
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT TOP 1 Username, Email
                                        FROM AspNetUsers;
                                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetFirstUser");
        }
    }
}
