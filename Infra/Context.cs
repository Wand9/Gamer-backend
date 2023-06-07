using gamer_beck.Controllers;
using gamer_beck.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_beck.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //STRING DE CONEXAO COM O BANCO
            //DATA SOURCE : O NOME DO SERVIDOR DO GERENCIADOR DO BANCO
            //INITIAL CATALOGO : NOME DO BANCO DE DADOS
            //INTEGRATED SECURITY : NOME DO BANCO DE DADOS 
            
            //AUTENTICACAO PELO WINDOWS
            //INTEGRATED SECURITY : AUTENTICACAO PELO WINDOWS
            //TRUSTSERVERCERTIFICATE : AUTENTICACAO PELO WINDOWS

            //AUTENTICACAO PELO SQLSERVER
            //ID USER = "NOME DO SEU USUARIO DE LOGIN"
            //PWD = "SENHA DO SEU USUARIO"
            
            optionsBuilder.UseSqlServer("Data source = NOTE13-S15; Initial Catalog = gamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true");
            }
        }


        public DbSet<Jogador> Jogador {get; set;}
        public DbSet<Equipe> Equipe {get; set;}


    } 
}