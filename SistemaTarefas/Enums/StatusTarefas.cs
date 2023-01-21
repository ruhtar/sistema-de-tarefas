using System.ComponentModel;

namespace SistemaTarefas.Enums
{
    public enum StatusTarefas
    {
        [Description("Tarefa a ser feita")]
        AFazer=1,
        [Description("Tarefa em andamento")]
        EmAndamento = 2 ,
        [Description("Tarefa concluída")]
        Concluida = 3 ,

    }
}
