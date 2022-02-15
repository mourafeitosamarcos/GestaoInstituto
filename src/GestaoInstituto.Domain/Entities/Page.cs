using System.ComponentModel.DataAnnotations;

namespace GestaoInstituto.Domain.Entities
{
    public class Page
    {
        public virtual int Id { get; set; }
                
        public int? PaiId { get; set; }
        public int? ModuloId { get; set; }
        public string Nome { get; set; }
        public string Path { get; set; }
        public string Icone { get; set; }
        public int? Ordem { get; set; }
        public int? Status { get; set; }
        public virtual bool Excluido { get; set; }
    }
}
