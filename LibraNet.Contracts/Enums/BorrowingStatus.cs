using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Enums
{
    public enum BorrowingStatus
    {

        [Display(Name = "Active")]
        Active,

        [Display(Name = "Prolonged")]
        Prolonged,

        [Display(Name = "Closed")]
        Closed
    }
}
