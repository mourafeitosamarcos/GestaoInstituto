using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Domain.Entity
{
    public class Usuario: BaseEntity
    {
        public int? InstituicaoId { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int? NivelAcesso { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int? Status { get; set; }

        [NotMapped]
        public List<int> PaginasId { get; set; }
        
        [NotMapped]
        public ValidationResult validationResult { get; set; }

        public bool IsValid()
        {
            validationResult = new UsuarioValidator().Validate(this);
            return validationResult.IsValid;
        }
        public class UsuarioValidator : AbstractValidator<Usuario>
        {
            public UsuarioValidator()
            {
                RuleFor(x => x.Nome).MinimumLength(5).WithMessage("Nome pequeno de mais");
                RuleFor(x => x.Nome).MaximumLength(80).WithMessage("Nome maior do que o permitido");
                RuleFor(x => x.Email).NotNull().WithMessage("E-mail deve ser informado").EmailAddress().WithMessage("E-mail inválido");
               // RuleFor(x => x.Senha).NotEmpty().MinimumLength(5).WithMessage("Senha pequena de mais");
                RuleFor(x => x.NivelAcesso).NotNull().NotEqual(0).WithMessage("Nível de acesso deve ser informado");
                RuleFor(x => x.Status).NotNull().NotEqual(0).WithMessage("Status deve ser informado");
            }
        }

    }
}
