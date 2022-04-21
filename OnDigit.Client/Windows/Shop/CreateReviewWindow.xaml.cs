using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Shop
{
    /// <summary>
    /// Interaction logic for CreateReviewWindow.xaml
    /// </summary>
    public partial class CreateReviewWindow : Window
    {
        private readonly IReviewService _reviewService;
        private readonly string _userId;
        public CreateReviewWindow(IReviewService reviewService, string userId)
        {
            InitializeComponent();
            _reviewService = reviewService;
            _userId = userId;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int CalculateStars()
        {
            int count = 0;
            if (star_1.Kind == PackIconKind.Star)
                count++;

            if (star_2.Kind == PackIconKind.Star)
                count++;

            if (star_3.Kind == PackIconKind.Star)
                count++;

            if (star_4.Kind == PackIconKind.Star)
                count++;

            if (star_5.Kind == PackIconKind.Star)
                count++;

            return count;
        }

        private void SendReview_Click(object sender, RoutedEventArgs e)
        {
            _reviewService.AddReviewAsync(
                new TextRange(CommentField.Document.ContentStart, CommentField.Document.ContentEnd).Text,
                CalculateStars(),
                _userId
                );  

            CloseWindow_Click(sender, e);
        }

        private void star_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            star_1.Kind = PackIconKind.Star;
            star_1.Foreground = Brushes.Orange;
            star_2.Kind = PackIconKind.StarOutline;
            star_2.Foreground = Brushes.Gray;
            star_3.Kind = PackIconKind.StarOutline;
            star_3.Foreground = Brushes.Gray;
            star_4.Kind = PackIconKind.StarOutline;
            star_4.Foreground = Brushes.Gray;
            star_5.Kind = PackIconKind.StarOutline;
            star_5.Foreground = Brushes.Gray;
        }

        private void star_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            star_1_MouseLeftButtonDown(sender, e);
            star_2.Kind = PackIconKind.Star;
            star_2.Foreground = Brushes.Orange;
        }

        private void star_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            star_2_MouseLeftButtonDown(sender, e);
            star_3.Kind = PackIconKind.Star;
            star_3.Foreground = Brushes.Orange;
        }

        private void star_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            star_3_MouseLeftButtonDown(sender, e);
            star_4.Kind = PackIconKind.Star;
            star_4.Foreground = Brushes.Orange;
        }

        private void star_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            star_4_MouseLeftButtonDown(sender, e);
            star_5.Kind = PackIconKind.Star;
            star_5.Foreground = Brushes.Orange;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
