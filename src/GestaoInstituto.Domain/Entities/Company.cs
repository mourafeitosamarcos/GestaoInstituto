using System;

namespace GestaoInstituto.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeContatoResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int QauntidadePessoas { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtivacao { get; set; }
        public DateTime DataInativacao { get; set; }
        public int Status { get; set; }
    }
}
