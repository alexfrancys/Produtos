using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Migrations
{
    public partial class SeedProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Produtos",
                new[] {
                "Id",
                "Codigo",
                "Nome",
                "Estoque",
                "Valor"
                },
                new object[,]
                {
                    {"9b3229a5-5b29-42b7-b685-ddfec68f26ff",100,"Panela",10,35.90 },
                    {"0d251ac5-4abc-4da5-a8e1-3b14eb3267b3",200,"Tapete",50,10.90 },
                    {"44b435df-1aea-46ad-9fce-ee539684fd2f",300,"Cama",6, 800 },
                    {"a37e8243-579e-42b6-91cc-7949aae25ee3",400,"Televisao",12,3500 },
                    {"6cf5ddcb-5516-4604-91a5-fff591f2eb6f",500,"Geladeira",10,2590 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Produtos",
                "Id",
                new object[]
                {
                 "9b3229a5-5b29-42b7-b685-ddfec68f26ff",
                 "0d251ac5-4abc-4da5-a8e1-3b14eb3267b3",
                 "44b435df-1aea-46ad-9fce-ee539684fd2f",
                 "a37e8243-579e-42b6-91cc-7949aae25ee3",
                 "6cf5ddcb-5516-4604-91a5-fff591f2eb6f"
                });
        }
    }
}
