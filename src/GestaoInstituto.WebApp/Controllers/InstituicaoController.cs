using GestaoInstituto.Application.Commands.Institution;
using GestaoInstituto.Application.Querys.Institution;
using GestaoInstituto.Domain;
using GestaoInstituto.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoInstituto.WebApp.Controllers
{
    public class InstituicaoController : BaseController
    {
        private readonly IMediator _mediator;
        public InstituicaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            List<Institution> institutions = new List<Institution>();
            ListInstitutionQuery listaUsuarioQuery = new ListInstitutionQuery()
            {
            };

            var response = await _mediator.Send(listaUsuarioQuery);

            response.Switch(us =>
            {
                institutions = us;

            }, error =>
            {
                Alert(error.MessageError, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(institutions);
        }

        public IActionResult Cadastro()
        {
            Institution institution = new Institution();
            ModelState.Clear();
            return View(institution);
        }

        [HttpPost]

        public async Task<IActionResult> Cadastro(Institution institution)
        {
            if (institution.IsValid())
            {
                CreateInstitutionCommand createUsuarioCommand = new CreateInstitutionCommand()
                {
                    Institution = institution
                };

                var response = await _mediator.Send(createUsuarioCommand);

                response.Switch(us =>
                {
                    ModelState.Clear();

                    institution = new Institution();

                    Alert("Registro Salvo com sucesso!", Enums.NotificationMessageType.success, Enums.NotificationType.toast);

                }, error =>
                {
                    Alert(error.MessageError, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
                });

                return View(institution);
            }
            else
                return View(institution);
        }

        public async Task<IActionResult> Editar(int id)
        {
            Institution institution = new Institution();
            ConsultInstitutionQuery consultaUsuarioQuery = new ConsultInstitutionQuery()
            {
                Id = id
            };

            var response = await _mediator.Send(consultaUsuarioQuery);

            response.Switch(us =>
            {
                institution = us;

            }, error =>
            {
                Alert(error.MessageError, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(institution);

        }

        [HttpPost]

        public async Task<IActionResult> Editar(Institution institution)
        {
            if (institution.IsValid())
            {
                UpdateInstitutionCommand updateUsuarioCommand = new UpdateInstitutionCommand()
                {
                    Institution = institution
                };

                var response = await _mediator.Send(updateUsuarioCommand);

                response.Switch(us =>
                {
                    ModelState.Clear();

                    institution = new Institution();

                    Alert("Registro Salvo com sucesso!", Enums.NotificationMessageType.success, Enums.NotificationType.toast);

                }, error =>
                {
                    Alert(error.MessageError, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
                });

                return View(institution);

            }
            else
                return View(institution);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            bool deleteSuccess = false;
            string messageError = string.Empty;

            DeleteInstitutionCommand updateUsuarioCommand = new DeleteInstitutionCommand()
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
