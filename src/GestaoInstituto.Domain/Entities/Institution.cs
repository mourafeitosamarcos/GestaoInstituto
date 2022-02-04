using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace GestaoInstituto.Domain.Entities
{
    public class Institution : BaseEntity
    {
        public virtual int AdministracaoId { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Status { get; set; }


        public virtual DateTime? DataInclusao { get; set; }
        public virtual DateTime? DataAlteracao { get; set; }
        public virtual DateTime? DataExclusao { get; set; }
        [NotMapped]
        public ValidationResult validationResult { get; set; }

        public bool IsValid()
        {
            validationResult = new InstitutionValidator().Validate(this);
            return validationResult.IsValid;
        }
        public class InstitutionValidator : AbstractValidator<Institution>
        {
            public InstitutionValidator()
            {
                RuleFor(x => x.Nome).MinimumLength(5).WithMessage("Nome pequeno de mais");
                RuleFor(x => x.Nome).MaximumLength(80).WithMessage("Nome maior do que o permitido");
                RuleFor(x => x.Email).NotNull().WithMessage("E-mail deve ser informado").EmailAddress().WithMessage("E-mail inválido");
                RuleFor(x => x.Status).NotNull().NotEqual(0).WithMessage("Status deve ser informado");
            }
        }
    }
}
