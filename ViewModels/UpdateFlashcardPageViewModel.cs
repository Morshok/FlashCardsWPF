using FlashCardsWPF.SQLiteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardsWPF.ViewModels
{
    public class UpdateFlashcardPageViewModel : BaseViewModel
    {
        private List<string> _uniqueTopics;
        public List<string> UniqueTopics { get { return _uniqueTopics; } set { _uniqueTopics = value; OnPropertyChanged("UniqueTopics"); } }

        private string _selectedTopic;
        public string SelectedTopic { get { return _selectedTopic; } set { _selectedTopic = value; OnPropertyChanged("SelectedTopic"); } }

        private List<string> _questionsByTopic = new List<string>();
        public List<string> QuestionsByTopic { get { return _questionsByTopic; } set { _questionsByTopic = value; OnPropertyChanged("QuestionsByTopic"); } }

        public UpdateFlashcardPageViewModel()
        {
            UniqueTopics = new List<string>();
            SelectedTopic = string.Empty;
            QuestionsByTopic = new List<string>();

            UpdateViewModel();
        }

        public async void UpdateViewModel(string? topic = null)
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;

            UniqueTopics = database.GetUniqueTopics();

            SelectedTopic = topic ?? (UniqueTopics?.FirstOrDefault());

            if (SelectedTopic != null)
            {
                QuestionsByTopic = database.GetQuestionsByTopic(SelectedTopic);
            }
        }

        public async void UpdateQuestionsByTopic()
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;
            QuestionsByTopic = database.GetQuestionsByTopic(SelectedTopic);
        }

        public async void DeleteFlashcard(string topic, string question)
        {
            if(string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(question))
            {
                //Inform user they need to specify either topic or question before proceeding
                return;
            }

            FlashcardDatabase database = await FlashcardDatabase.Instance;

            await database.DeleteItemAsync(topic, question);
        }

        public async void DeleteTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                //Inform user they need to specify topic before proceeding
                return;
            }

            FlashcardDatabase database = await FlashcardDatabase.Instance;

            await database.DeleteTopicAsync(topic);
        }
    }
}