﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.Entities
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
       
        public virtual bool Excluido { get; set; }
    }
}
