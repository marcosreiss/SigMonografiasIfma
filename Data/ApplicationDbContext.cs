using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SigMonografiasIfma.Models;

namespace SigMonografiasIfma.Data
{
    public class ApplicationDbContext : IdentityDbContext<Funcionario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Orientadores { get; set; }
        public DbSet<Monografia> Monografias { get; set; }
        
        //public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
