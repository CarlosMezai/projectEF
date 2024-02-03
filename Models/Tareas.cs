using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace projectEF.Models

public class Tarea
{
    public Guid TareaId {get; set;}
    public Guid CategoriaId {get; set;}
}