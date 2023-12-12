using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigMonografiasIfma.Models;
using System;

namespace SigMonografiasIfma.Data.DataSeed
{
    public class AdmDataSeed
    {
        public AdmDataSeed(ModelBuilder modelBuilder, UserManager<Funcionario> userManager, RoleManager<IdentityRole> roleManager )
        {
            // Criação de funções (roles)
            roleManager.CreateAsync(new IdentityRole("Chefe")).Wait();

            // Criação de usuário
            var usuario = new Funcionario
            {
                UserName = "ChefeSetor",
                Login = "ChefeSetor",
                Email = "admin@example.com",
                Nome = "Administrador",
                Telefone = "98989133135",
                Cidade = "São Luís",
                Campus = "Monte Castelo",
                NivelAcesso = Enuns.TipoFuncionario.ChefeSetor,
                PhoneNumber = "98989133135",

            };

            userManager.CreateAsync(usuario, "Senha@123").Wait();

            // Atribuição da função ao usuário
            userManager.AddToRoleAsync(usuario, "Chefe").Wait();

        }
    }
}
