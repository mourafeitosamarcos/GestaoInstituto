using GestaoInstituto.Application.Commands.Institution.DeleteInstitution;
using GestaoInstituto.Application.Commands.Institution.UpdateInstitutions;
using GestaoInstituto.Application.Handlers.Institution.CreateInstitution;
using GestaoInstituto.Application.Querys.Administration.ListAdministration;
using GestaoInstituto.Application.Querys.Institution.ConsultInstitutionQuery;
using GestaoInstituto.Application.Querys.Institution.ListInstitution;
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
                institutions = us.Institutions;

            }, error =>
            {
                Alert(error, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
            });

            return View(institutions);
        }

        public async Task<IActionResult> Cadastro()
        {
            Institution institution = new Institution();
            ModelState.Clear();

            ListAdministrationQuery listAdministrationQuery = new ListAdministrationQuery()
            {
            };

            var response = await _mediator.Send(listAdministrationQuery);

            response.Switch(adms =>
            {
                ViewBag.Administations = adms.Administrations.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() })
                                                             .ToList().OrderBy(ord => ord.Text);

            }, error =>
            {
            });
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
                    Alert(error, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
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
                institution = us.Institution;

            }, error =>
            {
                Alert(error, Enums.NotificationMessageType.error, Enums.NotificationType.toast);
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
                    Alert(error, Enums.NotificationMessageType.warning, Enums.NotificationType.toast);
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
                messageError = error;
            });

            if (deleteSuccess)
                return Ok();
            else
                return BadRequest(messageError);
        }
    }
}
