
using GestaoInstituto.Application.Commands.User;
using GestaoInstituto.Application.Querys.Administration;
using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Domain;
using GestaoInstituto.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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
            List<User> usuarios = new List<User>();
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

        public async Task<IActionResult> Cadastro()
        {
            User usuario = new User();
            ModelState.Clear();

            ListAdministrationQuery listAdministrationQuery = new ListAdministrationQuery()
            {
            };

            var response = await _mediator.Send(listAdministrationQuery);

            response.Switch(adms =>
            {
                ViewBag.Administations = adms.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() })
                                                             .ToList().OrderBy(ord => ord.Text);

            }, error =>
            {
            });

            return View(usuario);
        }

        [HttpPost]

        public async Task<IActionResult> Cadastro(User usuario)
        {
            if (usuario.IsValid())
            {
                CreateUserCommand createUsuarioCommand = new CreateUserCommand()
                {
                    User = usuario
                };

                var response = await _mediator.Send(createUsuarioCommand);

                response.Switch(us =>
                {
                    ModelState.Clear();

                    usuario = new User();

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
            User usuario = new User();
            ConsultUserQuery consultaUsuarioQuery = new ConsultUserQuery()
            {
                Id = id
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

        public async Task<IActionResult> Editar(User usuario)
        {
            if (usuario.IsValid())
            {
                UpdateUserCommand updateUsuarioCommand = new UpdateUserCommand()
                {
                    User = usuario
                };

                var response = await _mediator.Send(updateUsuarioCommand);

                response.Switch(us =>
                {
                    ModelState.Clear();

                    usuario = new User();

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
