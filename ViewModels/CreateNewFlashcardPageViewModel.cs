using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardsWPF.Models;
using FlashCardsWPF.SQLiteDatabase;

namespace FlashCardsWPF.ViewModels
{
    public class CreateNewFlashcardPageViewModel : BaseViewModel
    {
        private List<string> _uniqueTopics;
        public List<string> UniqueTopics { get { return _uniqueTopics; } set { _uniqueTopics = value; OnPropertyChanged("UniqueTopics"); } }

        private string _selectedTopic;
        public string SelectedTopic { get { return _selectedTopic; } set { _selectedTopic = value; OnPropertyChanged("SelectedTopic"); } }

        private List<string> _questionsByTopic = new List<string>();
        public List<string> QuestionsByTopic { get { return _questionsByTopic; } set { _questionsByTopic = value; OnPropertyChanged("QuestionsByTopic"); } }

        public CreateNewFlashcardPageViewModel()
        {
            UniqueTopics = new List<string>();
            SelectedTopic = string.Empty;
            QuestionsByTopic = new List<string>();

            PrepareViewModel();
        }

        public async void CreateNewFlashcard(string topic, string question, string answer)
        {
            Flashcard flashcard = new Flashcard(topic, question, answer);

            FlashcardDatabase database = await FlashcardDatabase.Instance;
            await database.SaveItemAsync(flashcard);

            PrepareViewModel(topic);
        }

        private async void Checkout()
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;
            database.CheckoutColumnNames();
        }

        public async void UpdateQuestionsByTopic(string topic)
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;
            QuestionsByTopic = database.GetQuestionsByTopic(SelectedTopic);
        }

        private async void PrepareViewModel(string? topic = null)
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;

            UniqueTopics = database.GetUniqueTopics();

            SelectedTopic = topic ?? (UniqueTopics?.FirstOrDefault());

            if (SelectedTopic != null)
            {
                QuestionsByTopic = database.GetQuestionsByTopic(SelectedTopic);
            }
        }

        private async void DropDatabaseTable()
        {
            FlashcardDatabase database = await FlashcardDatabase.Instance;
            await database.DropTableAsync();
        }
    }
}