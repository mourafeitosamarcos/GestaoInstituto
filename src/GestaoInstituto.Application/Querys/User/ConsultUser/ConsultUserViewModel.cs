using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.User.ConsultUser
{
    public class ConsultUserViewModel
    {
        public ConsultUserViewModel()
        {
            this.User = new Domain.Entities.User();
            this.User.AdministracaoIds = new List<int>();
            this.User.PaginaIds = new List<int>();

        }
        public Domain.Entities.User User { get; set; }
    }
}
