using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models.Database;

namespace YungChingProgram.Servicves
{
    public class ColumnCRUDService
    {
        private readonly TestDBEntities _db = new TestDBEntities();
        /// <summary>
        /// 取得人員類別下拉式選單
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetTypeSelectList()
        {
            try
            {
                var selectListData = (from category in _db.Category
                                      where category.Class_group == "ptype" && category.Flag == "Y"
                                      select new SelectListItem { Text = category.Name, Value = category.Code }).ToList();
                return selectListData;
            }
            catch (Exception ex)
            {
                return new List<SelectListItem>();
            }
        }
    }
}