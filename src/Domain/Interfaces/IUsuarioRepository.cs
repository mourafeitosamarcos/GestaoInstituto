﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        public bool ExistLogin(string email);
    }
}
