using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.Page.ListPage
{
    public class ListPageViewModel
    {
        public ListPageViewModel()
        {
            this.Pages = new List<Domain.Entities.Page>();
        }
        public List<Domain.Entities.Page> Pages { get; set; }
    }
}
