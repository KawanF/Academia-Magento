using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaMagento.Infra.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class retornandodenovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "DataValidade",
            table: "Matriculas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
           name: "DataValidade",
           table: "Matriculas",
           type: "datetime2",
           nullable: true);
        }
    
    }
}
