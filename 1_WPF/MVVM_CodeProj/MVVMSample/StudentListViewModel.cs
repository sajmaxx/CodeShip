using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVMSample
{
    public class StudentListViewModel : INotifyPropertyChanged
    {        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Func<ObservableCollection<StudentViewModel>> GetStudentsDelegate = null;
        public Action<ObservableCollection<StudentViewModel>> SaveStudentsDelegate = null;

        ObservableCollection<StudentViewModel> _theStudents = null;

        public ObservableCollection<StudentViewModel> TheStudents
        {
            get
            {
                return _theStudents;
            }

            set
            {
                if (_theStudents == value)
                    return;

                if (_theStudents != null)
                {
                    foreach (var StudentViewModel in _theStudents)
                    {
                        DisconnectStudentViewModel(StudentViewModel);
                    }
                }

                _theStudents = value;

                if (_theStudents != null)
                {
                    foreach (var StudentViewModel in _theStudents)
                    {
                        ConnectStudentViewModel(StudentViewModel);
                    }
                }

                OnPropertyChanged("TheStudents");
            }
        }

        void Student_DeleteStudentEvent(StudentViewModel StudentViewModel)
        {
            DisconnectStudentViewModel(StudentViewModel);
            TheStudents.Remove(StudentViewModel);
        }

        void ConnectStudentViewModel(StudentViewModel StudentViewModel)
        {
            StudentViewModel.DeleteStudentEvent += Student_DeleteStudentEvent;
        }

        void DisconnectStudentViewModel(StudentViewModel StudentViewModel)
        {
            StudentViewModel.DeleteStudentEvent -= Student_DeleteStudentEvent;
        }

        public void GetStudentsAction()
        {
            TheStudents = GetStudentsDelegate();

            IsSaveStudentsActionEnabled = true;
            IsAddStudentsActionEnabled = true;
        }

        bool _isSaveStudentsActionEnabled = false;

        public bool IsSaveStudentsActionEnabled
        {
            get
            {
                return _isSaveStudentsActionEnabled;
            }

            set
            {
                _isSaveStudentsActionEnabled = value;

                OnPropertyChanged("IsSaveStudentsActionEnabled");
            }
        }

        public void SaveStudentsAction()
        {
            if (SaveStudentsDelegate != null)
                SaveStudentsDelegate(TheStudents);
        }

        bool _isAddStudentsActionEnabled = false;

        public bool IsAddStudentsActionEnabled
        {
            get
            {
                return _isAddStudentsActionEnabled;
            }

            set
            {
                _isAddStudentsActionEnabled = value;

                OnPropertyChanged("IsAddStudentsActionEnabled");
            }
        }

        public void AddStudentAction()
        {
            StudentViewModel newStudentVM = new StudentViewModel { FirstName = null, LastName = null };

            ConnectStudentViewModel(newStudentVM);

            TheStudents.Add(newStudentVM);
        }
    }
}
