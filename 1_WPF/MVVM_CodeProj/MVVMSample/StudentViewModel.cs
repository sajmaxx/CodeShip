using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MVVMSample
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Action<StudentViewModel> DeleteStudentEvent = null;

        string _firstName = null;
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        string _lastName = null;
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        double _gradePointAverage = 0.0;
        public double GradePointAverage
        {
            get
            {
                return _gradePointAverage;
            }

            set
            {
                _gradePointAverage = value;
                OnPropertyChanged("GradePointAverage");
            }
        }

        public void DeleteStudentAction()
        {
            if (DeleteStudentEvent != null)
                DeleteStudentEvent(this);
        }
    }
}
