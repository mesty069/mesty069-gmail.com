using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models;

namespace YungChingProgram.ViewModels
{
    public class ColumnCRUDViewModel
    {
        public SelectList TypeSelectList { get; set; } = new SelectList(new List<SelectListItem>());
    }

    public class ColumnCRUDPartialViewModel : ColumnCRUDViewModel
    {
        public List<ColumnCRUDDataModel> ColumnCRUDDataModelList { get; set; }
    }
}