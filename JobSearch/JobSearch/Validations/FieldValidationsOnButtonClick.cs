using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearch.Validations
{
    public class FieldValidationsOnButtonClick
    {
        public bool CheckForEmptyJobName(string jobName)
        {
            if (string.IsNullOrEmpty(jobName) && string.IsNullOrWhiteSpace(jobName))
            {
                return false;
            }
            else return true;
        }

        public bool CheckForInvalidHoursField(string hours)
        { double val;
            if (!double.TryParse(hours, out val))
            {
                return false;
            }
            else if (val == 0)
            {
                return false;
            }
            else return true;
        }

        public bool CheckForEmptyAssignedToField(string assignedTo)
        {
            if (string.IsNullOrEmpty(assignedTo) && string.IsNullOrWhiteSpace(assignedTo))
            {
                return false;
            }
            else return true;
        }
    }
}
