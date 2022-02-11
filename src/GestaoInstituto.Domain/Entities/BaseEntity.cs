using System.ComponentModel.DataAnnotations;

namespace GestaoInstituto.Domain.Entities
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int? Status { get; set; }
        public virtual bool Excluido { get; set; }
    }
}
