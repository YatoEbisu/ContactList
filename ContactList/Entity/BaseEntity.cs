﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
    }
}
