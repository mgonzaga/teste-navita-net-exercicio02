using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels
{
    public class TableResultViewModel<T> where T: class
    {
        public int totalRecords { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalPages {
            get {
                decimal dTotalPages = totalRecords / pageSize;
                return int.Parse(Math.Round(dTotalPages,MidpointRounding.ToEven).ToString());
            }
        }
        public IEnumerable<T> records { get; set; }
    }
}
