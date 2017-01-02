using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public enum FILL_FTITLE
    {
        START_LIST
        [Display(Name = "FILL_ITEM")]
        FILL_FITEM,

        END_LIST
    }
}