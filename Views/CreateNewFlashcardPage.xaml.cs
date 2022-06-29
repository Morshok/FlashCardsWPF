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

        private ListBoxItem CreateAnswerOptionTemplate()
        {
            ListBoxItem listBoxItem = new ListBoxItem();

            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            ColumnDefinition column3 = new ColumnDefinition();
            column1.Width = new GridLength(75);
            column2.Width = new GridLength(1, GridUnitType.Star);
            column3.Width = new GridLength(1, GridUnitType.Star);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.ColumnDefinitions.Add(column3);

            Label answerText = new Label();
            answerText.Content = "test123";

            TextBox inputTextbox = new TextBox();
            inputTextbox.Text = "Test123";
            inputTextbox.VerticalContentAlignment = VerticalAlignment.Center;
            inputTextbox.Width = 175;

            return listBoxItem;
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
