using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SigMonografiasIfma.Data.DataSeed;
using SigMonografiasIfma.Models;

namespace SigMonografiasIfma.Data
{
    public class ApplicationDbContext : IdentityDbContext<Funcionario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            string ADMIN_ID = "02174";
            string ROLE_ID = "341743";

            //seed admin role
            builder.Entity<Funcionario>().HasData(new Funcionario
            {
                Nome = "ChefeSetor",
                NormalizedUserName = "CHEFESETOR",
                Id = int.Parse(ROLE_ID),
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new Funcionario
            {
                Id = int.Parse(ROLE_ID),
                Email = "chefedesetor@email.com",
                EmailConfirmed = true,
                UserName = "ChefeSetor",
                Login = "ChefeSetor",
                Nome = "Chefe de Setor",
                Telefone = "98989133135",
                Cidade = "São Luís",
                Campus = "Monte Castelo",
                NivelAcesso = Enuns.TipoFuncionario.ChefeSetor,
                PhoneNumber = "98989133135",
                NormalizedUserName = "CHEFEDESETOR"
            };

            //set user password
            PasswordHasher<Funcionario> ph = new PasswordHasher<Funcionario>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Chefesetor123!");

            //seed user
            builder.Entity<Funcionario>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Orientadores { get; set; }
        public DbSet<Monografia> Monografias { get; set; }
        
        //public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
