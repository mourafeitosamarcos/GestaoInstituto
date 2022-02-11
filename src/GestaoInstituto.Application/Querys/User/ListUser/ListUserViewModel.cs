using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.User.ListUser
{
    public class ListUserViewModel
    {
        public ListUserViewModel()
        {
            this.Users = new List<Domain.Entities.User>();
        }
        public List<Domain.Entities.User> Users { get; set; }
    }
}
