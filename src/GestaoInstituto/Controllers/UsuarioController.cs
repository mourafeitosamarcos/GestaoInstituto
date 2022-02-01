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
            ModelState.Clear();
            return View(usuario);
        }

        public IActionResult Editar(Usuario usuario)
        {

            return View(usuario);
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            if (usuario.IsValid())
            {
                if (usuario.Id == 0)
                {
                    CreateUsuarioCommand createUsuarioCommand = new()
                    {
                        Usuario = usuario
                    };

                    var response = await _mediator.Send(createUsuarioCommand);

                    response.Switch(us =>
                    {
                        ModelState.Clear();

                        usuario = new Usuario();

                    }, error =>
                    {
                        TempData["msg"] = @$" Swal.fire(
                                          '',
                                          '{error.MessageError}',
                                          'warning'
                                        )";
                    });

                    return View("Cadastro", usuario);
                }
                else
                {
                    UpdateUsuarioCommand updateUsuarioCommand = new()
                    {
                        Usuario = usuario
                    };

                    var response = await _mediator.Send(updateUsuarioCommand);

                    ModelState.Clear();
                    return View("Cadastro", new Usuario());
                }
            }
            else
                return View("Cadastro", usuario);
        }
    }
}
