// using System.ComponentModel.DataAnnotations;

// namespace API.Models;
// public class Agenda
// {
//     public Agenda()
//     {
//         CriadoEm = DateTime.Now;
//         Id = Guid.NewGuid().ToString();
//         Contato = string.Empty;
//     }

//     public Agenda(string titulo, string descricao, string contato)
//     {
//         Titulo = titulo;
//         Descricao = descricao;
//         Contato = contato;
//         CriadoEm = DateTime.Now;
//         Id = Guid.NewGuid().ToString();
//     }

//     //Atributo ou propriedade - nome e descricao
//     public string? Id { get; set; }
    
//     //Data Annotations em C#

//     [Required(ErrorMessage = "Este campo é obrigatório!")]
//     public string? Titulo { get; set; }

//     [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caracteres!")]
//     [MaxLength(50, ErrorMessage = "Este campo deve ter no máximo 50 caracteres!")]
//     public string? Descricao { get; set; }

//     [Range(1, 1000, ErrorMessage = "O preço deve estar entre R$ 1,00 e R$ 1.000,00!")]
//     public string Contato { get; set; }
//     public int Quantidade { get; set; }
//     public DateTime CriadoEm { get; set; }

// }
// using System.ComponentModel.DataAnnotations;
// namespace API.Models;

public class Agenda{
    public string AgendaId { get; set; } = Guid.NewGuid().ToString();
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public string? Contato { get; set; }
    public string? Status { get; set; } = "Não iniciada";
}