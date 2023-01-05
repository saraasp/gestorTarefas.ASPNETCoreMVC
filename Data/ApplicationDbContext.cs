using Microsoft.EntityFrameworkCore;

using gestorTarefas.Models;
namespace gestorTarefas.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
            : base( options )   
        {
            
        }

        public DbSet<Funcionario> Tfuncionarios { get; set; }
        public DbSet<Cliente> Tclientes { get; set; }
        public DbSet<Tarefa> Ttarefas { get; set; }
        public DbSet<Categoria> Tcategorias { get; set; }
        public DbSet<LinhaTarefa> TlinhasTarefa { get; set; }
        public DbSet<Importancia> Timportancias { get; set; }

    }
}

