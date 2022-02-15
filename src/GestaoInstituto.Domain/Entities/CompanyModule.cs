using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Domain.Entities
{
    public class CompanyModule
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int ModuloId { get; set; }
    }
}
