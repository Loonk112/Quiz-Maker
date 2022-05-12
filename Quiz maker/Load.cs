using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class Load
    {
        public static List<string> LoadToStringList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<string> list = new List<string>();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (openFileDialog.ShowDialog() == true)
            {
                list = File.ReadLines(openFileDialog.FileName).ToList();
                list.Insert(0, openFileDialog.FileName);
            }
            return list;
        }
    }
}
