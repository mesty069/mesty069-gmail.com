using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models;
using YungChingProgram.Models.Database;
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

        public PartialViewResult ColumnCRUDPartialView(string name, string type)
        {
            try
            {
                ColumnCRUDPartialViewModel columnCRUDPartialViewModel = new ColumnCRUDPartialViewModel();
                columnCRUDPartialViewModel.ColumnCRUDDataModelList = _service.GetColumnCRUDDataList(name, type);
                var selectList = _service.GetTypeSelectList();
                selectList.Insert(0, new SelectListItem { Value = "", Text = "請選擇" });
                columnCRUDPartialViewModel.TypeSelectList = new SelectList(selectList, "Value", "Text");
                if (columnCRUDPartialViewModel.ColumnCRUDDataModelList == null)
                {
                    return PartialView(new ColumnCRUDPartialViewModel());
                }
                return PartialView(columnCRUDPartialViewModel);
            }
            catch (Exception ex)
            {
                return PartialView(new ColumnCRUDPartialViewModel());
            }
        }

        /// <summary>
        /// 新增或資料
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertColumnCRUDData(ColumnCRUD columnCRUDData)
        {
            try
            {
                //判斷PKEY是否有填寫
                if (string.IsNullOrEmpty(columnCRUDData.Id))
                {
                    return Json(new { result = "人員代號為必填欄位" });
                }
                var result = _service.InsertColumnCRUDData(columnCRUDData);
                return Json(new { result = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = "false" });
            }
        }

        /// <summary>
        /// 新增或修改資料
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateColumnCRUDData(ColumnCRUDDataModel columnCRUDDataModel)
        {
            try
            {
                //判斷PKEY是否有填寫
                if (string.IsNullOrEmpty(columnCRUDDataModel.Id))
                {
                    return Json(new { result = "false" });
                }
                var result = _service.UpdateColumnCRUDData(columnCRUDDataModel);
                return Json(new { result = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = "false" });
            }
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteColumnCRUDData(string pid)
        {
            try
            {
                //判斷PKEY是否有填寫
                if (string.IsNullOrEmpty(pid))
                {
                    return Json(new { result = "人員Id為空值，刪除失敗" });
                }
                var result = _service.DeleteColumnCRUDData(pid);
                return Json(new { result = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = "false" });
            }
        }
    }
}