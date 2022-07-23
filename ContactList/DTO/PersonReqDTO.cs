using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactList.DTO
{
    public class PersonReqDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
    