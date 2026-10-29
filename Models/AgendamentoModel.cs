namespace UbsAPI.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public string? CpfPaciente { get; set; }
        public string? CrmMedico { get; set; }
        public string? EspecialidadeMedico { get; set; }
        public DateTime DataEHoraAgendamento { get; set; }
        public string? UbsEndereco { get; set; }
        public string? Triagem { get; set; }
    }
}
