using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Website.WebUI.Areas.User.ViewComponents.User
{
	public class _NavbarViewComponentLayout : ViewComponent
	{
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

