using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace JobSearch.Models
{
    public class Job : IJob
    {
        private string name;
        private double hours;
        private string assigned;
        public string Name { get => name; set => name = value; }
        public double Hours { get => hours; set => hours = value; }
        public string Assigned { get => assigned; set => assigned = value; }


        public Job()
        {
            name = "";
            hours = 0;
            assigned = "";
        }

        public Job(string name, double hours, string assigned)
        {
            this.name = name;
            this.hours = hours;
            this.assigned = assigned;
        }

        public int CompareTo(IJob other)
        {
            return hours.CompareTo(other.Hours);
        }
    }
}
