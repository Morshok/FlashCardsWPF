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
    /// Interaction logic for StudyFlashcardsPage.xaml
    /// </summary>
    public partial class StudyFlashcardsPage : Page
    {
        private StudyFlashcardsPageViewModel viewModel = new StudyFlashcardsPageViewModel();
        private int CurrentQuestionNumberOutOfTotal = 1;
        public StudyFlashcardsPage()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void FlashcardsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var topic = (sender as ListView).SelectedItem as string;

            viewModel.SetSelectedTopic(topic);

            CurrentQuestionNumberOutOfTotal = 1;

            ContentGrid.Visibility = Visibility.Visible;
            QuestionTextBlock.Text = viewModel.GetQuestionText(CurrentQuestionNumberOutOfTotal - 1);

            viewModel.SetCurrentQuestionNumberOutOfTotal(CurrentQuestionNumberOutOfTotal);
        }

        private void PreviousQuestionButton_OnClicked(object sender, RoutedEventArgs e)
        {
            CurrentQuestionNumberOutOfTotal = (CurrentQuestionNumberOutOfTotal - 1 < 1) ? 1 : CurrentQuestionNumberOutOfTotal - 1;

            PreviousQuestionButton.IsEnabled = (CurrentQuestionNumberOutOfTotal > 1) ? true : false;
            NextQuestionButton.IsEnabled = true;

            viewModel.SetCurrentQuestionNumberOutOfTotal(CurrentQuestionNumberOutOfTotal);

            QuestionTextBlock.Text = viewModel.GetQuestionText(CurrentQuestionNumberOutOfTotal - 1);
        }

        private void NextQuestionButton_OnClicked(object sender, RoutedEventArgs e)
        {
            var NumberOfQuestions = viewModel.NumberOfQuestionsByTopic;
            CurrentQuestionNumberOutOfTotal = (CurrentQuestionNumberOutOfTotal + 1 > NumberOfQuestions) ? NumberOfQuestions : CurrentQuestionNumberOutOfTotal + 1;

            PreviousQuestionButton.IsEnabled = true;

            NextQuestionButton.IsEnabled = (CurrentQuestionNumberOutOfTotal < NumberOfQuestions) ? true : false;
            PreviousQuestionButton.IsEnabled = true;

            viewModel.SetCurrentQuestionNumberOutOfTotal(CurrentQuestionNumberOutOfTotal);

            QuestionTextBlock.Text = viewModel.GetQuestionText(CurrentQuestionNumberOutOfTotal - 1);
        }
    }
}
