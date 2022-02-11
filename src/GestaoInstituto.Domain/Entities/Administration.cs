using System;

namespace GestaoInstituto.Domain.Entities
{
    public class Administration : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
