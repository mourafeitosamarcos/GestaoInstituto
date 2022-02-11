using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Application.Querys.User.AuthenticateUser;
using GestaoInstituto.Domain;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestaoInstituto.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        bool _isAuth = false;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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

                AuthenticateUserQuery authenticateUserQuery = new AuthenticateUserQuery()
                {
                    Email = email,
                    Senha = senha
                };

                var response = await _mediator.Send(authenticateUserQuery);

                response.Switch(async us => await AuthUser(us.User), error => Alert(error, Enums.NotificationMessageType.error, Enums.NotificationType.toast));

                if (_isAuth)
                    return RedirectToAction("Index", "Dashboard");
                else
                    return View("index");


            }
            else
            {
                Alert("Usuário e/ou senha incorretos", Enums.NotificationMessageType.error, Enums.NotificationType.toast);
                return View("index");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task AuthUser(User usuario)
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

            _isAuth = true;
        }
    }
}