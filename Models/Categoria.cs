namespace gestorTarefas.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string? Designacao { get; set; }



        public virtual ICollection<Tarefa>? Tarefas { get; set; }
    }


}
