using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class Answer : INotifyPropertyChanged
    {
        #region Variables
        private string _name;
        private bool _correct;
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
        public bool Correct
        {
            get
            {
                return this._correct;
            }
            set
            {
                if (value != this._correct)
                {
                    this._correct = value;
                    OnPropertyChanged("Correct");
                }
            }
        }
        #endregion

        public Answer(string name = "Answer", bool correct = false)
        {
            Name = name;
            Correct = correct;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
