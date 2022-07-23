using ContactList.Entity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ContactList.DTO
{
    public class PersonDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("contact_list")]
        public List<ContactDTO> Contacts { get; set; }
    }
}
