namespace GestaoInstituto.Domain.Entities
{
    public class Page: BaseEntity
    {
        public int? PaiId { get; set; }
        public int? ModuloId { get; set; }
        public string Nome { get; set; }
        public string Path { get; set; }
        public string Icone { get; set; }
        public int? Ordem { get; set; }
    }
}
