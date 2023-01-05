namespace gestorTarefas.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }


        
        public virtual ICollection<Tarefa>? Tarefas { get; set; }

    }
}
