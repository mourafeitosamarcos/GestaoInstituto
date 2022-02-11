using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Domain.Entities
{
    public class UserAdministration
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int AdministracaoId { get; set; }
    }
}
