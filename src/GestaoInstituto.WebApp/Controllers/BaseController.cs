using Microsoft.AspNetCore.Mvc;
using static GestaoInstituto.Domain.Enums;

namespace GestaoInstituto.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public void Alert(string message, NotificationMessageType notificationMessageType, NotificationType notificationType1)
        {
            if (notificationType1 == NotificationType.swallAlert)
                TempData["msg"] = $" Swal.fire( '', '{message}', '{notificationMessageType}')";
            else if (notificationType1 == NotificationType.toast)
                TempData["msg"] = $"toastr[\"{notificationMessageType}\"](\"{message}\")";
        }
    }
}
