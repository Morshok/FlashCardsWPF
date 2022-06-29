using FlashCardsWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FlashCardsWPF.Views
{
    /// <summary>
    /// Interaction logic for CreateNewFlashcardPage.xaml
    /// </summary>
    public partial class CreateNewFlashcardPage : Page
    {
        private CreateNewFlashcardPageViewModel viewModel = new CreateNewFlashcardPageViewModel();
        public CreateNewFlashcardPage()
        {
            DataContext = viewModel;

            InitializeComponent();
        }
        private void CreateNewFlashcardButton_OnClicked(object sender, RoutedEventArgs e)
        {
            var topic = TopicComboBox.Text;
            var question = QuestionTextBox.Text;
            var answer = AnswerTextBox.Text;

            viewModel.CreateNewFlashcard(topic, question, answer);

            QuestionTextBox.Text = string.Empty;
            AnswerTextBox.Text = string.Empty;
        }

        private void TopicComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            TopicComboBox.DataContext = viewModel;
        }

        private void TopicComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var topic = TopicComboBox.SelectedItem as string;

            viewModel.UpdateQuestionsByTopic(topic);
        }
    }
}
