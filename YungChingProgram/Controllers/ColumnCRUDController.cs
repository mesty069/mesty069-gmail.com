using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Servicves;
using YungChingProgram.ViewModels;

namespace YungChingProgram.Controllers
{
    public class ColumnCRUDController : Controller
    {
        private readonly ColumnCRUDService _service = new ColumnCRUDService();
        public ActionResult Index()
        {
            try
            {
                ColumnCRUDViewModel columnCRUDViewModel = new ColumnCRUDViewModel();
                var selectList = _service.GetTypeSelectList();
                selectList.Insert(0, new SelectListItem { Value = "", Text = "請選擇" });
                columnCRUDViewModel.TypeSelectList = new SelectList(selectList, "Value", "Text");
                return View(columnCRUDViewModel);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}