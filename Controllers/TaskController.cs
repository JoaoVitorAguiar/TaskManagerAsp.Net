using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.ViewModels.Tarefa;

namespace TaskManager.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly DataContext _context;

    public TaskController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("v1/Tarefas")]
    public async Task<IActionResult> GetAsync()
    {
        var tarefas = await _context.Tarefas.ToListAsync();
        return Ok(tarefas);
    }

    [HttpGet("v1/Tarefas/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id
        )
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x=>x.Id == id);
        if (tarefa == null)
        {
            return BadRequest("Tarefa não encontrada");
        }
        return Ok(tarefa);
    }

    [HttpPost("v1/Tarefas")]
    public async Task<IActionResult> PostAsync(
        [FromBody] TarefaRegisterViewModel model
        )
    {
        var tarefa = new Tarefa
        {
            Title = model.Title,
            Description = model.Description,
            CreatedDate = model.CreatedDate,
            Status = model.Status
        };
        await _context.AddRangeAsync(tarefa);
        await _context.SaveChangesAsync();
        return Created($"v1/Tarefas/{tarefa.Id}", tarefa);
    }

    [HttpDelete("v1/Tarefas/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id
        )
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        if (tarefa == null)
        {
            return BadRequest("Tarefa não encontrada");
        }
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
        return Ok(tarefa);
    }

    [HttpPut("v1/Tarefas/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] TarefaRegisterViewModel model
        )
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        if (tarefa == null)
        {
            return BadRequest("Tarefa não encontrada");
        }
        tarefa.Title = model.Title;
        tarefa.Description = model.Description;
        tarefa.CreatedDate = model.CreatedDate;
        tarefa.Status = model.Status;

        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
        return Ok(tarefa);
    }
}
