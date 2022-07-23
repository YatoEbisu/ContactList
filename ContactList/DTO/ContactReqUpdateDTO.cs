using ContactList.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactList.DTO
{
    public class ContactReqUpdateDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [JsonPropertyName("person_id")]
        public Guid PersonId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [JsonPropertyName("contact_type")]
        public ContactType Type { get; set; }
    }
}
