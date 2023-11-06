using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4058d8b2-4874-46b9-9c53-a3ad1fe7f0ca", "AQAAAAEAACcQAAAAEGjI7E/2uqr7qsMLn2Pge7vu/sekSjlf7yuZ1rlTjkNKaziPHQEbUyJeLls/9nZPvg==", "d8a3d8aa-8e6e-4abd-bc23-968e45a8d216" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea8b861b-25ec-49bc-a815-8f73def81152", "AQAAAAEAACcQAAAAEB5spvT7HkMveut2ey4dGsvMkvEHvRMnnp6OBntjJG6ZpoofXYz2ePpjFWFA9+DTmQ==", "612962be-bccd-4744-8616-f347620554cf" });
        }
    }
}
