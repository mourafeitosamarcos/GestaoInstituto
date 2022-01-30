using Domain.Entity;
using GestaoInstituto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace GestaoInstituto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index([Bind] string email, string senha)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioLogado = new Usuario
                {
                    Email = email,
                    Senha = senha,
                    Nome = "",
                    Id = 1,
                    NivelAcesso = 1
                };

                if (usuarioLogado != null)
                {
                    await AuthUser(usuarioLogado);
                }
                else
                {
                    //int.TryParse(_configuration["idConfiguracao"], out int idConfiguracao);

                    //Configuracao configuracao = _configuracaoApp.BuscaId(idConfiguracao);

                    //ViewBag.ConfiguracaoNomeSistema = configuracao == null ? "Gestão de Igrejas" : configuracao.NomeExibicao;
                    //ViewBag.ConfiguracaoLogoTipo = configuracao == null ? "" : configuracao.LogTipo;

                    //Toastr("O login Falhou. Informe as credenciais corretas", Domain.Enums.NotificationType.warning);
                    return View("index");
                }
            }
            else
            {
                return View("index");
            }

            return RedirectToAction("Index", "Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task AuthUser(Usuario usuario)
        {
            var claims = new List<Claim>
{
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim(ClaimTypes.Email, usuario.Email),
                        new Claim("NivelAcesso", usuario.NivelAcesso.ToString()),
                        new Claim("UsuarioLogado", JsonConvert.SerializeObject(usuario))
};

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    IsPersistent = true,
                    AllowRefresh = false
                });
        }
    }
}