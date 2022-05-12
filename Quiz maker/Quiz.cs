using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class Quiz : INotifyPropertyChanged
    {
        #region Variables
        private string _name;
        private string _description;
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
        public string Description
        {
            get { return this._description; }
            set
            {
                if (value != this._description)
                {
                    this._description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public ObservableCollection<Question> questions { get; set; }
        #endregion
        public Quiz(string name = "Quiz", string description = "Quiz description")
        {
            Name = name;
            Description = description;
            questions = new ObservableCollection<Question>();
            questions.Add(new Question());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
