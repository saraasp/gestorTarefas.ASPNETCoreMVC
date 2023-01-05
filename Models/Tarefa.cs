using System.ComponentModel.DataAnnotations;

namespace gestorTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Display(Name = "Data Criação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "Introduza uma descrição da tarefa")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Introduza uma data limite")]
        [Display(Name = "Data Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Data Resolução")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string? DataResolucao { get; set; } 

        [Required(ErrorMessage = "Introduza um cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [Display(Name = "Funcionário")]
        public int FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        [Required(ErrorMessage = "Introduza uma categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

        [Required(ErrorMessage = "Introduza importância")]
        [Display(Name = "Importância")]
        public int ImportanciaId { get; set; }
        public virtual Importancia? Importancia { get; set; }

        public bool Coima { get; set; }

        [Display(Name = "Resolvida?")]
        public bool Estado { get; set; } = false;

        public virtual ICollection<LinhaTarefa>? LinhasTarefas { get; set; }




    }
}
