using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class PageRepository : BaseRepository<Page, int>, IPageRepository
    {
        private readonly GestaoContext _context;

        public PageRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }
    }
}