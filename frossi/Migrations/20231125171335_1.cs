using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace frossi.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Descri = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposExamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposExamenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDoc = table.Column<int>(type: "int", nullable: false),
                    NroDoc = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitantes_TiposDoc_IdTipoDoc",
                        column: x => x.IdTipoDoc,
                        principalTable: "TiposDoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaPreguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoExamen = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RtaCorrecta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaPreguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaPreguntas_TiposExamenes_IdTipoExamen",
                        column: x => x.IdTipoExamen,
                        principalTable: "TiposExamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaHechos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoExamen = table.Column<int>(type: "int", nullable: false),
                    IdSolicitante = table.Column<int>(type: "int", nullable: false),
                    Correctas = table.Column<int>(type: "int", nullable: false),
                    Incorrectas = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaHechos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaHechos_Solicitantes_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaHechos_TiposExamenes_IdTipoExamen",
                        column: x => x.IdTipoExamen,
                        principalTable: "TiposExamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaOpciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    TextoOpcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaOpciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaOpciones_ExaPreguntas_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "ExaPreguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposDoc",
                columns: new[] { "Id", "Descri", "Nombre" },
                values: new object[,]
                {
                    { 1, "Documento Nacional de Identidad", "DNI" },
                    { 2, "Libreta Cívica", "LC" },
                    { 3, "Pasaporte", "PA" }
                });

            migrationBuilder.InsertData(
                table: "TiposExamenes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Motocicletas" },
                    { 2, "Automóviles" },
                    { 3, "Profesional" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Email", "Nombre", "Password", "Salt" },
                values: new object[] { 1, "fabio_d_rossi@hotmail.com", "FabioLo", "3276a0d74a9f4ca3f3959825dcba457d19e1f9340aa404abbcde25af2fb3b272", null });

            migrationBuilder.InsertData(
                table: "ExaPreguntas",
                columns: new[] { "Id", "IdTipoExamen", "PathImagen", "RtaCorrecta", "Texto" },
                values: new object[,]
                {
                    { 1, 1, "", 1, "¿Cuál es la función principal de los cinturones de seguridad en un vehículo?" },
                    { 2, 1, "", 3, "¿Qué significa una luz amarilla intermitente en un semáforo?" },
                    { 3, 1, "", 1, "¿Cuál es la distancia de seguimiento recomendada para mantener en condiciones de lluvia o niebla?" }
                });

            migrationBuilder.InsertData(
                table: "Solicitantes",
                columns: new[] { "Id", "Apellido", "Email", "IdTipoDoc", "Nombres", "NroDoc" },
                values: new object[,]
                {
                    { 1, "Rossi", null, 1, "Diego Armando", "20514866" },
                    { 2, "Carra", null, 1, "Rafaela", "20514877" }
                });

            migrationBuilder.InsertData(
                table: "ExaOpciones",
                columns: new[] { "Id", "IdPregunta", "Orden", "TextoOpcion" },
                values: new object[,]
                {
                    { 1, 1, 1, "Reducir el riesgo de lesiones en caso de accidente." },
                    { 2, 1, 2, "Mantener el vehículo en una velocidad segura." },
                    { 3, 1, 3, "Mejorar la eficiencia del combustible." },
                    { 4, 2, 1, "Prepararse para detenerse." },
                    { 5, 2, 2, "Acelerar para cruzar antes de que cambie a rojo." },
                    { 6, 2, 3, "Pasar con precaución si es seguro hacerlo." },
                    { 7, 3, 1, "Doble la distancia habitual." },
                    { 8, 3, 2, "Mantener la misma distancia que en condiciones normales." },
                    { 9, 3, 3, "Reducir la distancia a la mitad para tener una mejor visibilidad." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaHechos_IdSolicitante",
                table: "ExaHechos",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_ExaHechos_IdTipoExamen",
                table: "ExaHechos",
                column: "IdTipoExamen");

            migrationBuilder.CreateIndex(
                name: "IX_ExaOpciones_IdPregunta",
                table: "ExaOpciones",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_ExaPreguntas_IdTipoExamen",
                table: "ExaPreguntas",
                column: "IdTipoExamen");

            migrationBuilder.CreateIndex(
                name: "IX_TipoNroDoc",
                table: "Solicitantes",
                columns: new[] { "IdTipoDoc", "NroDoc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaHechos");

            migrationBuilder.DropTable(
                name: "ExaOpciones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropTable(
                name: "ExaPreguntas");

            migrationBuilder.DropTable(
                name: "TiposDoc");

            migrationBuilder.DropTable(
                name: "TiposExamenes");
        }
    }
}
