using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entity
{
    [Table("tbl_persons")]
    public class Person : BaseEntity
    {
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("contact_list")]
        public List<Contact> Contacts { get; set; }
    }
}
