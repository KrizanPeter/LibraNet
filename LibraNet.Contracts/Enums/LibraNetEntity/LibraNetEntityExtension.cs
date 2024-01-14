using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Enums.LibraNetEntity
{
    public static class LibraNetEntityExtension
    {
        public static string GetEnumName(this LibraNetEntity libraNetEntity) {

            var field = libraNetEntity.GetType().GetField(libraNetEntity.ToString());
            var attribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

            return attribute?.Name ?? libraNetEntity.ToString();
        }
    }
}
