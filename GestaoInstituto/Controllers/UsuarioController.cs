using Application.Commands;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInstituto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro(Usuario usuario)
        {

            return View(usuario);
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuario)
        {
            CreateUsuarioCommand createUsuarioCommand = new CreateUsuarioCommand
            {
                Usuario = usuario
            };

            var response = await _mediator.Send(createUsuarioCommand);

            return View(response);
        }
    }
}
