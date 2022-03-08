using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Response
{
    public class PaginationFilter
    {
        /// <summary>
        /// Current page number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Numbers of record 
        /// </summary>
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 20;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 20 ? 20 : pageSize;
        }
    }
}
