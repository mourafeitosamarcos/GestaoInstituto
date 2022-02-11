using System.Collections.Generic;

namespace GestaoInstituto.Application.Querys.Administration.ListAdministration
{
    public class ListAdministrationViewModel
    {
        public ListAdministrationViewModel()
        {
            this.Administrations = new List<Domain.Entities.Administration>();
        }

        public List<Domain.Entities.Administration> Administrations { get; set; }
    }
}
