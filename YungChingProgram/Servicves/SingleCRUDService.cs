using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models;
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

        /// <summary>
        /// 取得多筆人員資料
        /// </summary>
        /// <returns></returns>
        public List<SingleCRUDModel> GetSingleCRUDDataList(string name, string type)
        {
            try
            {
                var singleCRUDDataList = (from singleData in _db.SingleCRUD
                                          where (string.IsNullOrEmpty(name) || singleData.Name.Contains(name)) &&
                                          (string.IsNullOrEmpty(type) || singleData.Dtype == type)
                                          select new SingleCRUDModel
                                          {
                                              Dtype = singleData.Dtype,
                                              Id = singleData.Id,
                                              Name = singleData.Name,
                                              HeadCount = singleData.Headcount
                                          }).ToList();
                return singleCRUDDataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}