using Microsoft.AspNetCore.Mvc;
using ProjetoGerenciadorDeTarefas.Context;
using ProjetoGerenciadorDeTarefas.Models;

namespace ProjetoGerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefaId = _context.Tarefas.Find(id);

            if (tarefaId == null)
                return NotFound();

            return Ok(tarefaId);
        }

        [HttpGet]
        public IActionResult ObterTodasTarefas()
        {
            var Tarefas = _context.Tarefas.ToList();

            return Ok(Tarefas);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
                return NotFound();

            _context.Remove(tarefa);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, Tarefa tarefa)
        {
            var tarefaAtualizada = _context.Tarefas.Find(id);

            if (tarefa == null)
                return NotFound();

            tarefaAtualizada.Titulo = tarefa.Titulo;
            tarefaAtualizada.Descriçao = tarefa.Descriçao;
            tarefaAtualizada.Data = tarefa.Data;
            tarefaAtualizada.Status = tarefa.Status;

            _context.Update(tarefa);
            _context.SaveChanges();

            return Ok(tarefa);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo == titulo).ToList();

            if (tarefas.Count == 0)
                return NotFound();

            return Ok(tarefas);
        }


        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime Data)
        {
            var data = _context.Tarefas.FirstOrDefault(x => x.Data == Data);

            if (data == null)
                return NotFound();

            return Ok(data);

            
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status).ToList();

            if (tarefas.Count == 0)
                return NotFound();

            return Ok(tarefas);
        }


        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);

        }
    }
}