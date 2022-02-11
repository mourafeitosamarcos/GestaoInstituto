using System.Collections.Generic;

namespace GestaoInstituto.WebApp.Models
{
    public class UserAutorizeViewModel
    {
        public int UserId { get; set; }
        public List<int> PageIds { get; set; }
        public List<int> AdministrationIds { get; set; }
    }
}
