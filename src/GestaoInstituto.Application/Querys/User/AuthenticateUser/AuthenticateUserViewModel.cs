using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.User.AuthenticateUser
{
    public class AuthenticateUserViewModel
    {
        public AuthenticateUserViewModel()
        {
            this.User  = new Domain.Entities.User();
        }
        public Domain.Entities.User User { get; set; }
    }
}
