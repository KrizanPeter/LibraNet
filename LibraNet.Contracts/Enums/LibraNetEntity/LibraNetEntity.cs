using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Enums.LibraNetEntity
{
    public enum LibraNetEntity
    {
        [Display(Name = "Book")]
        Book,
        [Display(Name = "Borrowing")]
        Borrowing,
    }
}
