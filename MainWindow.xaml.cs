using FlashCardsWPF.Views;
using System.Windows;

namespace FlashCardsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_OnClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StudyButton_OnClicked(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new StudyFlashcardsPage());
        }

        private void UpdateButton_OnClicked(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new UpdateFlashcardPage());
        }

        private void CreateButton_OnClicked(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new CreateNewFlashcardPage());
        }
    }
}