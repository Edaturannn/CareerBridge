using Microsoft.AspNetCore.Mvc;
using System;
namespace Website.WebUI.Areas.User.ViewComponents.User
{
	public class _HeadViewComponentLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

