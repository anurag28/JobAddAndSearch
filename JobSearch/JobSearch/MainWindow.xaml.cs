using JobSearch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using JobSearch.Validations;

namespace JobSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Job> displayJobs = null;
        private ObservableCollection<Job> displaySearchedJobs = null;
        JobList jobList = new JobList();
        JobList savedJobList = new JobList();
        JobList searchJobList = new JobList();
        FieldValidationsOnButtonClick fieldValidation = null;

        public ObservableCollection<Job> DisplayJobs { get=>displayJobs; set=>displayJobs=value; }
        public ObservableCollection<Job> DisplaySearchedJobs { get=>displaySearchedJobs; set=>displaySearchedJobs=value; }

        public MainWindow()
        {
            InitializeComponent();
            displayJobs = new ObservableCollection<Job>();
            displaySearchedJobs = new ObservableCollection<Job>();
            fieldValidation = new FieldValidationsOnButtonClick();
            ReadFromFileOnLoading();
            DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValueValid = true;
            string errorMsgJob="";
            string errorMsgHours = "";
            string errorMsgAssignedTo = "";
            if (!fieldValidation.CheckForEmptyJobName(txtJobName.Text))
            {
                isValueValid = false;
                errorMsgJob = "Job Name Field Cannot Be Empty\n";
            }

            if (!fieldValidation.CheckForInvalidHoursField(txtHours.Text))
            {
                isValueValid = false;
                errorMsgHours = "Invalid or Empty Hours\n";
            }

            if (!fieldValidation.CheckForEmptyAssignedToField(txtAssignedTo.Text))
            {
                isValueValid = false;
                errorMsgAssignedTo = "Assigned To field Cannot Be Empty";
            }

            if (!isValueValid)
            {
                MessageBox.Show(errorMsgJob + errorMsgHours + errorMsgAssignedTo, "ERROR!!");
                ClearForm();
            }
            else
            {
                Job newJob = new Job(txtJobName.Text.ToLower(), double.Parse(txtHours.Text), txtAssignedTo.Text);
                DisplayJobs.Add(newJob);
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtJobName.Text = string.Empty;
            txtHours.Text = string.Empty;
            txtAssignedTo.Text = string.Empty;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            jobList.Clear();
            foreach(Job job in DisplayJobs)
            {
                jobList.Add(job);
            }
            if (jobList.Count() == 0)
            {
                MessageBox.Show("Empty Data Cannot Be Saved On File!!", "ERROR!");
            }
            else
            {
                if (WriteToFile())
                {
                    MessageBox.Show("Successfully Saved To File!!");
                }
            }
        }

        private bool WriteToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(JobList));
            TextWriter _writer = new StreamWriter("jobs.xml");
            serializer.Serialize(_writer, jobList);
            _writer.Close();
            return true;
        }

        public void ReadFromFileOnLoading()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(JobList));
            TextReader _reader = new StreamReader("jobs.xml");
            savedJobList = (JobList)serializer.Deserialize(_reader);
            _reader.Close();
            foreach(Job job in savedJobList.JobsList)
            {
                DisplayJobs.Add(job);
            }
        }

        private void ReadAndSearchJob()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(JobList));
            TextReader _reader = new StreamReader("jobs.xml");
            searchJobList = (JobList)serializer.Deserialize(_reader);
            //    foreach(Job job in searchJobList)
            //    {
            //        displaySearchedJobs.Add(job);
            //    }
            //}
            _reader.Close();

        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchJobList.Clear();
            DisplaySearchedJobs.Clear();
            ReadAndSearchJob();
            var query = from job in searchJobList.JobsList
                        where job.Name.ToLower().Contains(txtSearch.Text)
                        select job;
            if (query.Count() == 0)
            {
                MessageBox.Show("No Matching Results Found!!", "INFO");
            }
            else
            {
                foreach (Job job in query)
                {
                    DisplaySearchedJobs.Add(job);
                }
            }
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtSearch.Text== "Search by Job Name")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search by Job Name";
            }
        }

        private void txtHours_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtHours.Text == "0")
            {
                txtHours.Text = "";
            }
        }

        private void txtHours_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtHours.Text == "")
            {
                txtHours.Text = "0";
            }
        }
    }
}
