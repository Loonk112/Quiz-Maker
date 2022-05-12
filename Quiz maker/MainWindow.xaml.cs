using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Quiz_maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Quiz quiz;
        public MainWindow()
        {
            InitializeComponent();
            quiz = new Quiz();

            #region List Bindings
            QuestionsList.ItemsSource = quiz.questions;
            QuestionsList.SelectedIndex = 0;
            AnswersList.ItemsSource = quiz.questions[QuestionsList.SelectedIndex].Answers;
            AnswersList.SelectedIndex = 0;
            #endregion
            #region TB Bindings
            QuizNameInput.DataContext = quiz;
            QuizDescriptionInput.DataContext = quiz;
            QuestionNameInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];
            QuestionPointsInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];
            #endregion
        }

        
        private void NumericalOnlyTB(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #region Buttons
        private void QuizImportB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> list = Load.LoadToStringList();
                Quiz tmpQuiz = new Quiz();
                tmpQuiz.questions.RemoveAt(0);
                string workString = list[1];
                workString = workString.Substring(1, workString.Length - 2);
                List<string> workList = workString.Split($"\";\"").ToList();
                // Quiz
                tmpQuiz.Name = workList[0];
                tmpQuiz.Description = workList[1];
                int lineCount = 2;
                bool answerCorrect;
                Trace.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                Trace.WriteLine(workString);
                int QCount = Int32.Parse(workList[2]);
                for (int i = 0; i < QCount; i++)
                {
                    workString = list[lineCount];
                    workString = workString.Substring(1, workString.Length - 2);
                    workList = workString.Split($"\";\"").ToList();
                    tmpQuiz.questions.Add(new Question(workList[0], Int32.Parse(workList[1])));
                    tmpQuiz.questions.Last().Answers.RemoveAt(0);
                    tmpQuiz.questions.Last().Answers.RemoveAt(0);
                    lineCount++;
                    Trace.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    Trace.WriteLine(workString);
                    int ACount = Int32.Parse(workList[2]);
                    for (int j = 0; j < ACount; j++)
                    {
                        workString = list[lineCount];
                        workString = workString.Substring(1, workString.Length - 2);
                        workList = workString.Split($"\";\"").ToList();
                        if (workList[1] == "T")
                        {
                            answerCorrect = true;
                        }
                        else
                            answerCorrect = false;
                        tmpQuiz.questions.Last().Answers.Add(new Answer(workList[0], answerCorrect));
                        lineCount++;
                        Trace.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                        Trace.WriteLine(workString);
                    }
                }
                quiz = tmpQuiz;

                #region List Bindings
                QuestionsList.ItemsSource = quiz.questions;
                QuestionsList.SelectedIndex = 0;
                AnswersList.ItemsSource = quiz.questions[QuestionsList.SelectedIndex].Answers;
                AnswersList.SelectedIndex = 0;
                #endregion
                #region TB Bindings
                QuizNameInput.DataContext = quiz;
                QuizDescriptionInput.DataContext = quiz;
                QuestionNameInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];
                QuestionPointsInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];
                #endregion

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }

        private void QuizExportB_Click(object sender, RoutedEventArgs e)
        {
            Save.SaveObjectToTxt(quiz);
        }

        private void QuestionNewB_Click(object sender, RoutedEventArgs e)
        {
            quiz.questions.Add(new Question());
            QuestionsList.SelectedIndex = quiz.questions.Count - 1;
        }

        private void QuestionDelB_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.questions.Count > 1)
            {
                int _oldSelection = QuestionsList.SelectedIndex;
                if (QuestionsList.SelectedIndex == 0)
                {
                    QuestionsList.SelectedIndex = 1;
                }
                else
                    QuestionsList.SelectedIndex--;
                quiz.questions.RemoveAt(_oldSelection);
            }
        }

        private void AnswerNewB_Click(object sender, RoutedEventArgs e)
        {
            quiz.questions[QuestionsList.SelectedIndex].Answers.Add(new Answer());
            AnswersList.SelectedIndex = quiz.questions[QuestionsList.SelectedIndex].Answers.Count - 1;
        }

        private void AnswerDelB_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.questions[QuestionsList.SelectedIndex].Answers.Count > 2)
            {
                int _oldSelection = AnswersList.SelectedIndex;
                if (AnswersList.SelectedIndex == 0)
                {
                    AnswersList.SelectedIndex = 1;
                }
                else
                    AnswersList.SelectedIndex--;
                quiz.questions[QuestionsList.SelectedIndex].Answers.RemoveAt(_oldSelection);
            }
        }
        #endregion

        private void QuestionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnswersList.ItemsSource = quiz.questions[QuestionsList.SelectedIndex].Answers;
            QuestionNameInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];
            QuestionPointsInput.DataContext = quiz.questions[QuestionsList.SelectedIndex];

        }
    }
}
