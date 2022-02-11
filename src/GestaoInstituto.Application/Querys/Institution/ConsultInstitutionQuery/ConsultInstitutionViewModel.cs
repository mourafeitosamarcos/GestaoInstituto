namespace GestaoInstituto.Application.Querys.Institution.ConsultInstitutionQuery
{
    public  class ConsultInstitutionViewModel
    {
        public ConsultInstitutionViewModel()
        {
            this.Institution = new Domain.Entities.Institution();
        }

        public Domain.Entities.Institution Institution { get; set; }
    }
}
