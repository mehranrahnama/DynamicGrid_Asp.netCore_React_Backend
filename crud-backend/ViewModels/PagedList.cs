using System.Collections.Generic;

namespace ViewModels
{
    public class PagedList<T>
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public string Expression { get; set; }
        public int Count { get; set; }
        public string SortBy { get; set; }
        public string SortMethod { get; set; }
        public ICollection<T> list { get; set; }
    }
}
