using ContactList.Entity;
using ContactList.Util;
using System;
using System.Text.Json.Serialization;

namespace ContactList.DTO
{
    public class ContactDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("contact_type")]
        public ContactType Type { get; set; }
    }
}
