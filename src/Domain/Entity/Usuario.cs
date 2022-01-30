using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Usuario: BaseEntity
    {
        public int InstituicaoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public int Status { get; set; }

        [NotMapped]
        public List<int> PaginasId { get; set; }
    }
}
