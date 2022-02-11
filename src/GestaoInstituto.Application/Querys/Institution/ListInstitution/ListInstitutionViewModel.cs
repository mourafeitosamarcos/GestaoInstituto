using System.Collections.Generic;

namespace GestaoInstituto.Application.Querys.Institution.ListInstitution
{
    public class ListInstitutionViewModel
    {
        public ListInstitutionViewModel()
        {
            this.Institutions = new List<Domain.Entities.Institution>();
        }
        public List<Domain.Entities.Institution> Institutions { get; set; }
    }
}
