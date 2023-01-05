using System.ComponentModel.DataAnnotations;

namespace gestorTarefas.Models
{
    public class LinhaTarefa
    {
        public int Id { get; set; }

        [Display(Name = "Tarefa")]
        public int TarefaId { get; set; }
        public virtual Tarefa? Tarefa { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Data { get; set; }

        [Display(Name = "Descrição do procedimento executado")]
        public string? Descricao { get; set; }

        [Display(Name = "Nome do Funcionário")]
        public string? NomeFuncionario { get; set; }

    }
}
