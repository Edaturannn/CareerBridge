using System;
using Microsoft.AspNetCore.Mvc;

namespace Website.WebUI.Areas.User.ViewComponents.User
{
	public class _SidebarViewComponentLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

