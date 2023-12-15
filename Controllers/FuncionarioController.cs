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
        //
        private readonly ILogger<FuncionarioController> _logger;


        public FuncionarioController(UserManager<Funcionario> userManager, SignInManager<Funcionario> signInManager, ILogger<FuncionarioController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


       
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
     
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
                    return RedirectToAction("Index", "Monografia");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult LoginR()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginR(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Monografia");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

       
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Monografia");
        }

    }
}
