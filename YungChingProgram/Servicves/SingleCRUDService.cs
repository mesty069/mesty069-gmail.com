using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models.Database;

namespace YungChingProgram.Servicves
{
    public class SingleCRUDService
    {
        private readonly TestDBEntities _db = new TestDBEntities();

        public List<SelectListItem> GetDtypeSelecList()
        {
            try
            {
                var selectListData = (from category in _db.Category
                                      where (category.Class_group == "dtype" && category.Flag == "Y")
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