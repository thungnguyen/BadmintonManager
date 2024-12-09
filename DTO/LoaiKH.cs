using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class LoaiKH
    {
      
            public string DisplayName { get; set; }  // Giá trị hiển thị có dấu
            public string Value { get; set; }        // Giá trị thực không dấu

            // Constructor
            public LoaiKH(string displayName, string value)
            {
                DisplayName = displayName;
                Value = value;
            }
       
    }
}
