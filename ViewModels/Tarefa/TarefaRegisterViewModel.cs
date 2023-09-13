using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.ViewModels.Tarefa;

public class TarefaRegisterViewModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    [EnumDataType(typeof(Status))]
    public Status Status { get; set; }
}
