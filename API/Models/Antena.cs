﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("antena")]
    public class Antena
    {
        [Key]
        public int id { get; set; }
        public string antena { get; set; }
    
    }
}