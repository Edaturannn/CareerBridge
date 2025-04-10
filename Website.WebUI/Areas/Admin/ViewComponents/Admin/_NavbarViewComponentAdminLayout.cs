using System;
using Microsoft.AspNetCore.Mvc;

namespace Website.WebUI.Areas.Admin.ViewComponents.Admin
{
	public class _NavbarViewComponentAdminLayout : ViewComponent
	{
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

