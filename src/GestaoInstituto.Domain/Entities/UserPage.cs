using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Domain.Entities
{
    public class UserPage
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PaginaId { get; set; }
    }
}
