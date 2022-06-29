using FlashCardsWPF.SQLiteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardsWPF.ViewModels
{
    public class StudyFlashcardsPageViewModel : BaseViewModel
    {
        private List<string> _uniqueTopics;
        public List<string> UniqueTopics { get { return _uniqueTopics; } set { _uniqueTopics = value; OnPropertyChanged("UniqueTopics"); } }

        private string _selectedTopic;
        public string SelectedTopic { get { return _selectedTopic; } set { _selectedTopic = value; OnPropertyChanged("SelectedTopic"); } }

        private string _currentQuestionNumberOutOfTotal;
        public string CurrentQuestionNumberOutOfTotal { get { return _currentQuestionNumberOutOfTotal; } set { _currentQuestionNumberOutOfTotal = value; OnPropertyChanged("CurrentQuestionNumberOutOfTotal"); } }

        private List<string> _questionsByTopic = new List<string>();
        public List<string> QuestionsByTopic { get { return _questionsByTopic; } set { _questionsByTopic = value; OnPropertyChanged("QuestionsByTopic"); } }

        private List<string> _answersByTopic = new List<string>();
        public List<string> AnswersByTopic { get { return _answersByTopic; } set { _answersByTopic = value; OnPropertyChanged("AnswersByTopic"); } }

        private int _numberOfQuestionsByTopic = 0;
        public int NumberOfQuestionsByTopic { get { return _numberOfQuestionsByTopic; } set { _numberOfQuestionsByTopic = value; OnPropertyChanged("NumberOfQuestionsByTopic"); } }

        public StudyFlashcardsPageViewModel()
        {
            UniqueTopics = new List<string>();
            SelectedTopic = string.Empty;
            QuestionsByTopic = new List<string>();
            AnswersByTopic = new List<string>();

            PrepareViewModel();
        }

        private async void PrepareViewModel()
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;

            UniqueTopics = database.GetUniqueTopics();
        }

        public async void SetSelectedTopic(string topic)
        {
            SelectedTopic = topic;

            FlashcardDatabase database = await FlashcardDatabase.Instance;
            QuestionsByTopic = database.GetQuestionsByTopic(SelectedTopic);
            AnswersByTopic = database.GetAnswersByTopic(SelectedTopic);

            NumberOfQuestionsByTopic = database.GetNumberOfQuestionsByTopic(SelectedTopic);
        }

        public void SetCurrentQuestionNumberOutOfTotal(int currentQuestionNumber)
        {
            CurrentQuestionNumberOutOfTotal = currentQuestionNumber + " out of " + NumberOfQuestionsByTopic;
        }

        public string GetQuestionText(int index)
        {
            return QuestionsByTopic[index]; 
        }

        public string GetAnswerText(int index) { return AnswersByTopic[index]; }
    }
}