using GestaoInstituto.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace GestaoInstituto.WebApp.Helper
{
    public class BasicAuthorizeAttribute : TypeFilterAttribute
    {
        public BasicAuthorizeAttribute() :
            base(typeof(AuthorizeAttribute))
        {
            Arguments = new object[]
            {
            };
        }
    }
    public class AuthorizeAttribute : IAuthorizationFilter
    {
        public static Usuario UsuarioLogado { get; set; }
        //public static List<Pagina> PaginasLiberadas { get; set; }
        //public string _permissoes { get; set; }

        public AuthorizeAttribute()
        {
        }

        //public string Permissoes { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Claims.Count() > 0)
            {
                //var NivelAcesso = context.HttpContext.User.Claims.Where(c => c.Type == "NivelAcesso").Select(c => c.Value).FirstOrDefault();
                //var Permissoes = context.HttpContext.User.Claims.Where(c => c.Type == "Permissoes").Select(c => c.Value).FirstOrDefault();
                //UsuarioLogado = JsonConvert.DeserializeObject<Usuario>(context.HttpContext.User.Claims.Where(c => c.Type == "UsuarioLogado").Select(c => c.Value).FirstOrDefault());
                //PaginasLiberadas = JsonConvert.DeserializeObject<List<Pagina>>(context.HttpContext.User.Claims.Where(c => c.Type == "Paginas").Select(c => c.Value).FirstOrDefault());
                //Enum.TryParse<Roles>(NivelAcesso, out _roleAcesso);

                //foreach (Pagina pagina in PaginasLiberadas.Where(pg => !pg.PaginaPaiId.HasValue))
                //{
                //    PaginasLiberadas.FirstOrDefault(pg => pg.Id == pagina.Id).SubMenus = PaginasLiberadas.Where(pg => pg.PaginaPaiId == pagina.Id).ToList();
                //}

                //if (!PaginasLiberadas.Where(x => context.HttpContext.Request.Path.ToString().ToLower().StartsWith(x.Path.ToLower()) && !string.IsNullOrEmpty(x.Path.ToLower())).Any())
                //    context.Result = new RedirectToRouteResult(
                //                  new RouteValueDictionary
                //                  {
                //                       { "action", "Index" },
                //                       { "controller", "Home" }
                //                  });

            }
            else
            {
                context.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                   });
            }


        }
    }
}
