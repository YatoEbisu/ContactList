using ContactList.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entity
{
    [Table("tbl_contacts")]
    public class Contact : BaseEntity
    {
        [Column("person_id")]
        public Guid PersonId { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("contact_type")]
        public ContactType Type { get; set; }
    }
}
