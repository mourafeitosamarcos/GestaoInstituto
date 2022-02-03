
using GestaoInstituto.Application.Commands.User;
using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Domain;
using GestaoInstituto.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoInstituto.WebApp.Controllers
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
            ListUserQuery listaUsuarioQuery = new ListUserQuery()
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
                CreateUserCommand createUsuarioCommand = new CreateUserCommand()
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
            ConsultUserQuery consultaUsuarioQuery = new ConsultUserQuery()
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
                UpdateUserCommand updateUsuarioCommand = new UpdateUserCommand()
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

            DeleteUserCommand updateUsuarioCommand = new DeleteUserCommand()
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
