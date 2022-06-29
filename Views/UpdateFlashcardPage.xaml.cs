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
    /// Interaction logic for UpdateFlashcardPage.xaml
    /// </summary>
    public partial class UpdateFlashcardPage : Page
    {
        private UpdateFlashcardPageViewModel viewModel = new UpdateFlashcardPageViewModel();

        public UpdateFlashcardPage()
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        private void FlashcardsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //UpdateFlashcardButton.IsEnabled = true; //To be added
            DeleteFlashcardButton.IsEnabled = true;
        }

        private void FlashcardSetsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (FlashcardsListView.Visibility == Visibility.Hidden) FlashcardsListView.Visibility = Visibility.Visible;
            if (FlashCardTitle.Visibility == Visibility.Hidden) FlashCardTitle.Visibility = Visibility.Visible;

            var topic = FlashcardSetsListView.SelectedItem as string;

            viewModel.SelectedTopic = topic;
            viewModel.UpdateQuestionsByTopic();

            DeleteSetButton.IsEnabled = true;
        }

        private void UpdateFlashcardButton_OnClicked(object sender, RoutedEventArgs e)
        {
            /*
                // To be added
            */
        }

        private void DeleteFlashcardButton_OnClicked(object sender, RoutedEventArgs e)
        {
            var topic = FlashcardSetsListView.SelectedItem as string;
            var question = FlashcardsListView.SelectedItem as string;

            viewModel.DeleteFlashcard(topic, question);
            viewModel.UpdateQuestionsByTopic();
        }

        private void DeleteSetButton_OnClicked(object sender, RoutedEventArgs e)
        {
            var topic = FlashcardSetsListView.SelectedItem as string;

            viewModel.DeleteTopic(topic);
            viewModel.UpdateViewModel();

            FlashcardsListView.Visibility = Visibility.Hidden;
            FlashCardTitle.Visibility = Visibility.Hidden;
        }
    }
}