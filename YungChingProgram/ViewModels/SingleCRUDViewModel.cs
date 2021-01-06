using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YungChingProgram.ViewModels
{
    public class SingleCRUDViewModel
    {
        public SelectList DTypeSelectList { get; set; } = new SelectList(new List<SelectListItem>());
        public string ErrorMessage { get; set; }

    }
}