using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SigMonografiasIfma.Models;

namespace SigMonografiasIfma.Controllers
{
    
    public class FuncionarioController : Controller
    {
        private readonly UserManager<Funcionario> _userManager;
        private readonly SignInManager<Funcionario> _signInManager;

        public FuncionarioController(UserManager<Funcionario> userManager, SignInManager<Funcionario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Registro(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                //copia os dados do RegistroViewModel para o funcionário
                var user = new Funcionario
                {
                    UserName = model.Login,
                    Login = model.Login,
                    Nome = model.Nome,
                    Telefone = model.Telefone,
                    PhoneNumber = model.Telefone,
                    Cidade = model.Cidade,
                    Campus = model.Campus,
                    NivelAcesso = Enuns.TipoFuncionario.FuncionarioComum
                };

                //armazena os dados do usuário na tabela AspNetUsers
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
