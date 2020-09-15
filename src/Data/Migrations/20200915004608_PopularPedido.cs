using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class PopularPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { "0C29956D-F54F-4C95-8030-533C11CF98E9", "Pedido de Feira" });


            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "Id", "Descricao", "PedidoId" },
                values: new object[] { "1D2134DB-C270-4D9D-8B9C-0608F12BF269", "Bananas", "0C29956D-F54F-4C95-8030-533C11CF98E9" });


            migrationBuilder.InsertData(
               table: "PedidoItens",
               columns: new[] { "Id", "Descricao", "PedidoId" },
               values: new object[] { "E4CEF3C2-BCBB-4BB2-8A65-F703E55C22EF", "Maças", "0C29956D-F54F-4C95-8030-533C11CF98E9" });


            migrationBuilder.InsertData(
              table: "PedidoItens",
              columns: new[] { "Id", "Descricao", "PedidoId" },
              values: new object[] { "50969D2F-3455-42C2-8F1E-C1A7D0690D27", "Peras", "0C29956D-F54F-4C95-8030-533C11CF98E9" });

            migrationBuilder.InsertData(
            table: "PedidoItens",
            columns: new[] { "Id", "Descricao", "PedidoId" },
            values: new object[] { "8E5AA953-99AD-4CFA-9EA3-855B4AEA2F6B", "Melão", "0C29956D-F54F-4C95-8030-533C11CF98E9" });


            migrationBuilder.InsertData(
               table: "PedidoItens",
               columns: new[] { "Id", "Descricao", "PedidoId" },
               values: new object[] { "86B7C37D-A426-4B02-A5E0-F3E881174BEC", "Uva", "0C29956D-F54F-4C95-8030-533C11CF98E9" });


            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "Id", "Descricao", "PedidoId" },
                values: new object[] { "E457DF93-DFC8-44E3-B9A9-7CBBE46D98CA", "Mexerica", "0C29956D-F54F-4C95-8030-533C11CF98E9" });

            migrationBuilder.InsertData(
               table: "PedidoItens",
               columns: new[] { "Id", "Descricao", "PedidoId" },
               values: new object[] { "BE846C01-51BE-434E-8CFC-C5256781695A", "Manga", "0C29956D-F54F-4C95-8030-533C11CF98E9" });

            migrationBuilder.InsertData(
              table: "PedidoItens",
              columns: new[] { "Id", "Descricao", "PedidoId" },
              values: new object[] { "A4B1EDF2-3937-41AE-8ED0-78A225FC969B", "Caqui", "0C29956D-F54F-4C95-8030-533C11CF98E9" });


            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "Id", "Descricao", "PedidoId" },
                values: new object[] { "C1F62822-19DB-4DDE-AA41-75645DC42A44", "Alface", "0C29956D-F54F-4C95-8030-533C11CF98E9" });

            migrationBuilder.InsertData(
               table: "PedidoItens",
               columns: new[] { "Id", "Descricao", "PedidoId" },
               values: new object[] { "A9D13CBE-B049-42D1-B631-7AEE9608D736", "Tomate", "0C29956D-F54F-4C95-8030-533C11CF98E9" });



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
               table: "PedidoItens",
               keyColumn: "Id",
               keyValue: "A9D13CBE-B049-42D1-B631-7AEE9608D736");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "C1F62822-19DB-4DDE-AA41-75645DC42A44");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "A4B1EDF2-3937-41AE-8ED0-78A225FC969B");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "BE846C01-51BE-434E-8CFC-C5256781695A");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "E457DF93-DFC8-44E3-B9A9-7CBBE46D98CA");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "86B7C37D-A426-4B02-A5E0-F3E881174BEC");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "8E5AA953-99AD-4CFA-9EA3-855B4AEA2F6B");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "50969D2F-3455-42C2-8F1E-C1A7D0690D27");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "E4CEF3C2-BCBB-4BB2-8A65-F703E55C22EF");
            migrationBuilder.DeleteData(
               table: "Pedido",
               keyColumn: "Id",
               keyValue: "1D2134DB-C270-4D9D-8B9C-0608F12BF269");

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: "0C29956D-F54F-4C95-8030-533C11CF98E9");

        }
    }
}
