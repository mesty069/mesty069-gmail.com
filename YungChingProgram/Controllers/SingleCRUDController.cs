using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Servicves;
using YungChingProgram.ViewModels;

namespace YungChingProgram.Controllers
{
    public class SingleCRUDController : Controller
    {
        private readonly SingleCRUDService _service = new SingleCRUDService();
        // GET: SingleCRUD
        public ActionResult Index()
        {
            try
            {
                SingleCRUDViewModel singleCRUDViewModel = new SingleCRUDViewModel();
                var selectList = _service.GetDtypeSelecList();
                selectList.Insert(0, new SelectListItem { Text = "請選擇", Value = "" });
                singleCRUDViewModel.DTypeSelectList = new SelectList(selectList, "Value", "Text");
                return View(singleCRUDViewModel);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}