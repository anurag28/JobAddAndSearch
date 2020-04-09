using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearch.Models
{
    public interface IJob : IComparable<IJob>
    {
        public string Name { get; set; }
        public double Hours { get; set; }
        public string Assigned { get; set; }
    }
}
