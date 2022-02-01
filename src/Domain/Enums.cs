using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Enums
    {
        public enum StatusUsuario
        {
            [Display(Name = "Ativo")]
            Ativo = 1,
            [Display(Name = "Inativo")]
            Inativo = 2
        }

        public enum NivelAcesso
        {
            [Display(Name = "Admin")]
            Admin = 1,
            [Display(Name = "Secretário Geral")]
            SecretarioGeral = 2,
            [Display(Name = "Tesoureiro Geral")]
            TesoureiroGeral = 3,
            [Display(Name = "Gestor")]
            Gestor = 4,
            [Display(Name = "Supervisor(a)")]
            Supervisor = 5,
            [Display(Name = "Coordenador(a)")]
            Coordenador = 6,
            [Display(Name = "Coordenadora Pedagógica")]
            CoordenadorPedagogico = 7,
            [Display(Name = "Professor(a)")]
            Professor = 8,
            [Display(Name = "Líder")]
            Lider = 9,
            [Display(Name = "Mentor")]
            Mentor = 10,
            [Display(Name = "Tutor")]
            Tutor = 11,
            [Display(Name = "Conselheiro Fiscal")]
            ConselheiroFiscal = 12,
            [Display(Name = "Conselheiro Colegiado")]
            ConselheiroColegiado = 13,
            [Display(Name = "Secretário")]
            Secretario = 14,
            [Display(Name = "Tesoureiro")]
            Tesoureiro = 15,
            [Display(Name = "Voluntário/ Estagiário")]
            VoluntarioEstagiario = 16,
            [Display(Name = "Organizador/ Responsável")]
            OrganizadorResponsavel = 17,
            [Display(Name = "Assistente Social")]
            AssistenteSocial = 18,
            [Display(Name = "Voluntário Assistente Social")]
            VoluntarioAssistenteSocial = 19,
            [Display(Name = "Voluntário")]
            Voluntario = 20,
            [Display(Name = "Estagiário")]
            Estagiario = 21,
            [Display(Name = "Colaborador")]
            Colaborador = 22,
            [Display(Name = "Auxiliar Geral")]
            AuxiliarGeral = 23,
            [Display(Name = "Captador de Recursos")]
            CaptadorRecursos = 24,
            [Display(Name = "Revisor")]
            Revisor = 25
        }
    }
}