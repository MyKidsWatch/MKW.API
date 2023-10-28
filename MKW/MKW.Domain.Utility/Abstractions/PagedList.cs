using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Utility.Abstractions
{
    public class PagedList<Entity> where Entity : class
    {
        public IEnumerable<Entity> Results { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page < PageCount;

        public PagedList()
        {

        }

        public PagedList<Entity> Convert<T>(PagedList<T> pagedList, Func<T, Entity> predicate) where T : class
        {
            PageCount = pagedList.PageCount;
            PageSize = pagedList.PageSize;
            Page = pagedList.Page;
            Results = pagedList.Results.Select(predicate);

            return this;
        }
    }
}
