using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungChingProgram.Models;

namespace YungChingProgram.ViewModels
{
    public class SingleCRUDViewModel
    {
        public SelectList DTypeSelectList { get; set; } = new SelectList(new List<SelectListItem>());
        public string ErrorMessage { get; set; }

    }
    public class SingleCRUDPartialViewModel : SingleCRUDViewModel
    {
        public List<SingleCRUDModel> SingleCRUDModelList { get; set; } = new List<SingleCRUDModel>();
    }
}