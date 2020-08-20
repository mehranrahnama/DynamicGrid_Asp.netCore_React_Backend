using System.Linq;
using ViewModels;

namespace Common
{
    public static class Pagging
    {
        /// <summary>
        /// paging 
        /// </summary>

        public static IQueryable<T> PagedResult<T>(IQueryable<T> query, paggingData paggingData)
        {
            if (paggingData.PageSize <= 0) paggingData.PageSize = 20;

           
            paggingData.Count = query.Count();

            if (paggingData.Count <= paggingData.PageSize || paggingData.PageNum <= 0) paggingData.PageNum = 1;

            int excludedRows = (paggingData.PageNum - 1) * paggingData.PageSize;

            return query.Skip(excludedRows).Take(paggingData.PageSize);
        }

       

    }
}
