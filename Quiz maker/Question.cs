using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class Question : INotifyPropertyChanged
    {
        #region Variables
        private string _name;
        private int _points;
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public int Points
        {
            get
            {
                return this._points;
            }
            set
            {
                if (value != this._points)
                {
                    this._points = value;
                    OnPropertyChanged("Points");
                }
            }
        }
        public ObservableCollection<Answer> Answers { get; set; }
        #endregion

        public Question(string name = "Question", int points = 0)
        {
            Name = name;
            Answers = new ObservableCollection<Answer>();
            Answers.Add(new Answer());
            Answers.Add(new Answer());
            Points = points;

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
