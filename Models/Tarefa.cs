using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGerenciadorDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descriçao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public EnumStatusTarefa Status { get; set; }

    }
}