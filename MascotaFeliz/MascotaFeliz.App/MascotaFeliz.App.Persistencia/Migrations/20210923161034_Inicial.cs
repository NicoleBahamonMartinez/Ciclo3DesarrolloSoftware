using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NroIdentificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroContacto = table.Column<long>(type: "bigint", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoProfesional = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NroIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueñoNroIdentificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Usuarios_DueñoNroIdentificacion",
                        column: x => x.DueñoNroIdentificacion,
                        principalTable: "Usuarios",
                        principalColumn: "NroIdentificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitasDomiciliarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    FrencuenciaCardiaca = table.Column<int>(type: "int", nullable: false),
                    FrencuenciaRespiratoria = table.Column<int>(type: "int", nullable: false),
                    EstadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicinas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncargadoNroIdentificacion = table.Column<int>(type: "int", nullable: true),
                    Pacienteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasDomiciliarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitasDomiciliarias_Mascotas_Pacienteid",
                        column: x => x.Pacienteid,
                        principalTable: "Mascotas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitasDomiciliarias_Usuarios_EncargadoNroIdentificacion",
                        column: x => x.EncargadoNroIdentificacion,
                        principalTable: "Usuarios",
                        principalColumn: "NroIdentificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_DueñoNroIdentificacion",
                table: "Mascotas",
                column: "DueñoNroIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasDomiciliarias_EncargadoNroIdentificacion",
                table: "VisitasDomiciliarias",
                column: "EncargadoNroIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasDomiciliarias_Pacienteid",
                table: "VisitasDomiciliarias",
                column: "Pacienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitasDomiciliarias");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
