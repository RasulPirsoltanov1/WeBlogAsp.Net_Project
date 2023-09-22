﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.EntityLayer.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate{ get; set; }
        public DateTime? UpdateDate{ get; set; }
		public bool Status { get; set; }
    }
}
