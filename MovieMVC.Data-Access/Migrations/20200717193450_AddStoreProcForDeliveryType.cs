using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMVC.Data_Access.Migrations
{
    public partial class AddStoreProcForDeliveryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetDeliveryTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.DeliveryTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetDeliveryType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.DeliveryTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateDeliveryType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.DeliveryTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteDeliveryType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.DeliveryTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateDeliveryType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.DeliveryTypes(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetDeliveryTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetDeliveryType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateDeliveryType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteDeliveryType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateDeliveryType");
        }
    }
}
