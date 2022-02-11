using GestaoInstituto.Application.Commands.User.AuthorizationUser;
using GestaoInstituto.Application.Commands.User.DeleteUser;
using GestaoInstituto.Application.Commands.User.UpdateUser;
using GestaoInstituto.Application.Handlers.User.CreateUser;
using GestaoInstituto.Application.Querys.Administration.ListAdministration;
using GestaoInstituto.Application.Querys.Page.ListPage;
using GestaoInstituto.Application.Querys.User.ConsultUser;
using GestaoInstituto.Application.Querys.User.ListUser;
using GestaoInstituto.Domain;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.WebApp.Models;
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
                usuarios = us.Users;

            }, error =>
            {
                Alert(error, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(usuarios);
        }

        public async Task<IActionResult> Cadastro()
        {
            User usuario = new User();
            ModelState.Clear();

            await LoadViewBag();

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
                    Alert(error, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
                });

                return View(usuario);
            }
            else
                return View(usuario);
        }

        public async Task<IActionResult> Editar(int id)
        {
            await LoadViewBag();

            User usuario = new User();

            ConsultUserQuery consultaUsuarioQuery = new ConsultUserQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(consultaUsuarioQuery);

            response.Switch(us =>
            {
                usuario = us.User;

            }, error =>
            {
                Alert(error, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
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
                    Alert(error, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
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
                messageError = error;
            });

            if (deleteSuccess)
                return Ok();
            else
                return BadRequest(messageError);
        }

        [HttpPost]
        public async Task<IActionResult> Autorizar([FromBody] UserAutorizeViewModel userAutorizeViewModel)
        {
            bool AuthotizationSuccess = false;
            string messageError = string.Empty;

            AuthorizationUserCommand authorizationUserCommand = new AuthorizationUserCommand()
            {
                UserId = userAutorizeViewModel.UserId,
                AdministrationIds = userAutorizeViewModel.AdministrationIds,
                PageIds = userAutorizeViewModel.PageIds,
            };

            var response = await _mediator.Send(authorizationUserCommand);
            response.Switch(us =>
            {
                AuthotizationSuccess = true;
            }, error =>
            {
                messageError = error;
            });

            if (AuthotizationSuccess)
                return Ok();
            else
                return BadRequest(messageError);
        }

        private async Task LoadViewBag()
        {
            ListAdministrationQuery listAdministrationQuery = new ListAdministrationQuery()
            {
            };

            var responseAdministration = await _mediator.Send(listAdministrationQuery);

            responseAdministration.Switch(adms =>
            {
                ViewBag.Administations = adms.Administrations.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() })
                                                             .ToList().OrderBy(ord => ord.Text);

            }, error =>
            {
            });


            ListPageQuery listPageQuery = new ListPageQuery();
            

            var responsePage = await _mediator.Send(listPageQuery);

            responsePage.Switch(adms =>
            {
                ViewBag.Pages = adms.Pages.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() })
                                                             .ToList().OrderBy(ord => ord.Text);

            }, error =>
            {
            });
        }
    }
}
