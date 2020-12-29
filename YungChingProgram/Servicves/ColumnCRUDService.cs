using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models;
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

        /// <summary>
        /// 取得多筆人員資料
        /// </summary>
        /// <returns></returns>
        public List<ColumnCRUDDataModel> GetColumnCRUDDataList(string name, string type)
        {
            try
            {
                var typeSelectList = GetTypeSelectList();
                var columnCRUDDataList = (from columnData in _db.ColumnCRUD
                                          where (string.IsNullOrEmpty(name) || columnData.Name.Contains(name)) &&
                                          (string.IsNullOrEmpty(type) || columnData.Type == type)
                                          select new ColumnCRUDDataModel
                                          {
                                              Sex = columnData.Sex,
                                              Id = columnData.Id,
                                              Name = columnData.Name,
                                              Tel = columnData.Tel,
                                              Type = columnData.Type,
                                              Address = columnData.Address
                                          }).ToList();
                return columnCRUDDataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string InsertColumnCRUDData(ColumnCRUD columnCRUDData)
        {
            try
            {
                ColumnCRUD columnCRUD = (from column in _db.ColumnCRUD
                                         where column.Id == columnCRUDData.Id
                                         select column).FirstOrDefault();
                //搜尋出重複資料，新增失敗
                if (columnCRUD != null)
                {
                    return "新增到重複ColumnCRUD資料，新增失敗";
                }
                columnCRUDData.Upuser = "admin";
                columnCRUDData.Updatetime = DateTime.Now;
                columnCRUDData.Cruser = "admin";
                columnCRUDData.Crdatetime = DateTime.Now;
                _db.ColumnCRUD.Add(columnCRUDData);
                _db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public string UpdateColumnCRUDData(ColumnCRUDDataModel columnCRUDDataModel)
        {
            try
            {
                ColumnCRUD columnCRUD = (from column in _db.ColumnCRUD
                                         where column.Id == columnCRUDDataModel.Id
                                         select column).FirstOrDefault();
                //查無資料，修改失敗
                if (columnCRUD == null)
                {
                    return "查無此修改資料，請確認人員編號是否異動或刪除";
                }
                _db.ColumnCRUD.Attach(columnCRUD);
                columnCRUD.Address = columnCRUDDataModel.Address;
                columnCRUD.Name = columnCRUDDataModel.Name;
                columnCRUD.Sex = columnCRUDDataModel.Sex;
                columnCRUD.Tel = columnCRUDDataModel.Tel;
                columnCRUD.Type = columnCRUDDataModel.Type;
                columnCRUD.Upuser = "admin";
                columnCRUD.Updatetime = DateTime.Now;
                _db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public string DeleteColumnCRUDData(string pid)
        {
            try
            {
                ColumnCRUD columnCRUD = (from column in _db.ColumnCRUD
                                         where column.Id == pid
                                         select column).FirstOrDefault();
                //查無資料，修改失敗
                if (columnCRUD == null)
                {
                    return "查無此刪除資料，請確認人員編號是否異動或已刪除";
                }
                _db.ColumnCRUD.Remove(columnCRUD);
                _db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
    }
}