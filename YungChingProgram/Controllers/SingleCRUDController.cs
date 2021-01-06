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

        public PartialViewResult SingleCRUDPartialView(string name, string type)
        {
            try
            {
                SingleCRUDPartialViewModel singleCRUDPartialViewModel = new SingleCRUDPartialViewModel();
                singleCRUDPartialViewModel.SingleCRUDModelList = _service.GetSingleCRUDDataList(name, type);
                if (singleCRUDPartialViewModel.SingleCRUDModelList == null)
                {
                    singleCRUDPartialViewModel.ErrorMessage = "查詢發生錯誤";
                    return PartialView(singleCRUDPartialViewModel);
                }
                var selectList = _service.GetDtypeSelecList();
                selectList.Insert(0, new SelectListItem { Value = "", Text = "請選擇" });
                singleCRUDPartialViewModel.DTypeSelectList = new SelectList(selectList, "Value", "Text");
                if (singleCRUDPartialViewModel.DTypeSelectList == null)
                {
                    return PartialView(new ColumnCRUDPartialViewModel());
                }
                return PartialView(singleCRUDPartialViewModel);
            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }
    }
}