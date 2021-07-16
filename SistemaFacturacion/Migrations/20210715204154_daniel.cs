using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaFacturacion.Migrations
{
    public partial class daniel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    idcategoria = table.Column<int>(type: "int", nullable: false),
                    cantidadActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_idcategoria",
                        column: x => x.idcategoria,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    subtotal = table.Column<double>(type: "float", nullable: false),
                    iva = table.Column<double>(type: "float", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    idcliente = table.Column<int>(type: "int", nullable: false),
                    createdday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    anulada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_idcliente",
                        column: x => x.idcliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subtotal = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    idfactura = table.Column<int>(type: "int", nullable: false),
                    idproducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_idfactura",
                        column: x => x.idfactura,
                        principalTable: "Facturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_idproducto",
                        column: x => x.idproducto,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Tecnologia" },
                    { 2, "Hogar" },
                    { 3, "Telvisores" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "apellido", "fecha_nacimiento", "nombre" },
                values: new object[,]
                {
                    { 1, "Fontalvo", new DateTime(1984, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose" },
                    { 2, "Diaz", new DateTime(1992, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enrique" },
                    { 3, "Mejia", new DateTime(1976, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrea" },
                    { 4, "Barrios", new DateTime(1983, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel" },
                    { 5, "Rodriguez", new DateTime(1989, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esneider" },
                    { 6, "Santiago", new DateTime(1986, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis" },
                    { 7, "Rincon", new DateTime(1984, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heidy" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "id", "idcategoria", "descripcion", "precio", "cantidadActual" },
                values: new object[,]
                {
                    { 1, 1, "Portátil ASUS VivoBook", 1449000.0,30 },
                    { 2, 1, "Portátil Gamer HP 15", 3199000.0,25 },
                    { 3, 1, "iMac con pantalla Retina", 4499000.0,24 },
                    { 4, 1, "All In One ASUS Vivo AIO", 1790000.0,12 },
                    { 5, 1, "Portátil HUAWEI Matebook", 2999000.0,17 },
                    { 6, 2, "Soumier", 329900.0,1 },
                    { 7, 2, "Silla Escritorio", 479900.0,36 },
                    { 8, 2, "Mesa plegable aluminio", 399900.0,4 },
                    { 9, 2, "colchon doble faz", 1499000.0,55 },
                    { 10, 2, "Equipo Mini Sony", 599900.0,17 },
                    { 11, 3, "TV Samsung 50 Pulgadas", 1999900.0,20 },
                    { 12, 3, "TV LG 50 Pulgadas", 2400000.0,23 },
                    { 13, 3, "TV Panasonic 50 Pulgadas", 2200000.0,26 },
                    { 14, 3, "TV Samsung 32 Pulgadas", 1300000.0,25 },
                    { 15, 3, "TV Challenger 50 Pulgadas", 1299900.0,21 },
                    { 16, 3, "TV Sony 50 Pulgadas", 2900000.0,11 }
                });


            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_idfactura",
                table: "DetalleFacturas",
                column: "idfactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_idproducto",
                table: "DetalleFacturas",
                column: "idproducto");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idcliente",
                table: "Facturas",
                column: "idcliente");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idcategoria",
                table: "Productos",
                column: "idcategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
