using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    internal class Save
    {
        public static void SaveObjectToTxt(object caller)
        {
            if(caller == null)
                return;
            else if(caller is Quiz)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Filter = "Quiz file (*.QMSave)|*.QMSave";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.DefaultExt = ".QMSave";
                if (saveFileDialog.ShowDialog() == true)
                {
                    List<string> list = new List<string>();
                    list.Add($"\"{((Quiz)caller).Name}\";\"{((Quiz)caller).Description}\";\"{((Quiz)caller).questions.Count}\"");
                    foreach (Question q in ((Quiz)caller).questions)
                    {
                        list.Add($"\"{q.Name}\";\"{q.Points}\";\"{q.Answers.Count}\"");
                        foreach (Answer a in q.Answers)
                        {
                            list.Add($"\"{a.Name}\";\"{BoolToString.BTS(a.Correct)}\"");
                        }
                    }
                    File.WriteAllLines(saveFileDialog.FileName, list);

                }

            }
        }
    }
}
