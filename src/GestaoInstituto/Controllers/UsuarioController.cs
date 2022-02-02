using Application.Commands;
using Application.Querys;
using Domain;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInstituto.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            ListaUsuarioQuery listaUsuarioQuery = new()
            {
            };

            var response = await _mediator.Send(listaUsuarioQuery);

            response.Switch(us =>
            {
                usuarios = us;

            }, error =>
            {
                Alert(error.MessageError, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(usuarios);
        }

        public IActionResult Cadastro()
        {
            Usuario usuario = new Usuario();
            ModelState.Clear();
            return View(usuario);
        }

        [HttpPost]

        public async Task<IActionResult> Cadastro(Usuario usuario)
        {
            if (usuario.IsValid())
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

                    Alert("Registro Salvo com sucesso!", Enums.NotificationMessageType.success, Enums.NotificationType.toast);

                }, error =>
                {
                    Alert(error.MessageError, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
                });

                return View(usuario);
            }
            else
                return View(usuario);
        }

        public async Task<IActionResult> Editar(int id)
        {
            Usuario usuario = new Usuario();
            ConsultaUsuarioQuery consultaUsuarioQuery = new()
            {
                UsuarioId = id
            };

            var response = await _mediator.Send(consultaUsuarioQuery);

            response.Switch(us =>
            {
                usuario = us;

            }, error =>
            {
                Alert(error.MessageError, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(usuario);

        }

        [HttpPost]

        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (usuario.IsValid())
            {
                UpdateUsuarioCommand updateUsuarioCommand = new()
                {
                    Usuario = usuario
                };

                var response = await _mediator.Send(updateUsuarioCommand);

                response.Switch(us =>
                {
                    ModelState.Clear();

                    usuario = new Usuario();

                    Alert("Registro Salvo com sucesso!", Enums.NotificationMessageType.success, Enums.NotificationType.toast);

                }, error =>
                {
                    Alert(error.MessageError, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
                });

                return View(usuario);

            }
            else
                return View(usuario);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            bool deleteSuccess = false;
            string messageError = string.Empty;

            DeleteUsuarioCommand updateUsuarioCommand = new()
            {
                Id = id
            };

            var response = await _mediator.Send(updateUsuarioCommand);
            response.Switch(us =>
            {
                deleteSuccess = true;
            }, error =>
            {
                messageError = error.MessageError;
            });

            if (deleteSuccess)
                return Ok();
            else
                return BadRequest(messageError);
        }
    }
}
