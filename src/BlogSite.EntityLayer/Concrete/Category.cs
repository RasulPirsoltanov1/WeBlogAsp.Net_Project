﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.EntityLayer.Concrete
{
    public class Category:BaseEntity
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
    }
}
