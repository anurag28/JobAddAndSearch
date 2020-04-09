using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace JobSearch.Models
{
    [XmlRoot("JobList")]
    public class JobList
    {
        private List<Job> jobsList = null;

        [XmlArray("Jobs")]
        [XmlArrayItem("Job", typeof(Job))]
        public List<Job> JobsList { get => jobsList; set => jobsList= value; }

        public JobList()
        {
            JobsList = new List<Job>();
        }

        public void Add(Job job)
        {
            JobsList.Add(job);
        }

        public void Remove(Job job)
        {
            JobsList.Remove(job);
        }

        public void Clear()
        {
            JobsList.Clear();
        }

        public int Count()
        {
            return JobsList.Count;
        }
    }
}
