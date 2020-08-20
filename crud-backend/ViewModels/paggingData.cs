using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
   public class paggingData
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public string Expression { get; set; }
        public int Count { get; set; }
        public string SortBy { get; set; }
        public string SortMethod { get; set; }
    }
}
