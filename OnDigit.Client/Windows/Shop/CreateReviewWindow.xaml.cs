using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using OnDigit.Client.Windows.Shop.Controls;
using OnDigit.Core.Interfaces.Services;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Client.Windows.Shop
{
    /// <summary>
    /// Interaction logic for CreateReviewWindow.xaml
    /// </summary>
    public partial class CreateReviewWindow : Window
    {
        private readonly IReviewService _reviewService;
        private readonly User _currentUser;
        private readonly Book _book;
        private readonly BookInfoWindow _bookInfoWindow;

        public CreateReviewWindow(BookInfoWindow bookInfoWindow, IReviewService reviewService, User currentUser, Book book)
        {
            InitializeComponent();
            _reviewService = reviewService;
            _book = book;
            _currentUser = currentUser;
            _bookInfoWindow = bookInfoWindow;
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

        private async void SendReview_Click(object sender, RoutedEventArgs e)
        {
            Review review = new()
            {
                Text = new TextRange(CommentField.Document.ContentStart, CommentField.Document.ContentEnd).Text,
                Stars = CalculateStars(),
                UserId = _currentUser.Id,
                BookId = _book.Id
            };

            _book.Rating = (_book.Rating * _book.Reviews.Count + review.Stars) / (_book.Reviews.Count + 1);

            await _reviewService.AddReviewAsync(review, _book);

            _bookInfoWindow.UpdateBookInfo(_book, review, _currentUser);

            CloseWindow_Click(sender, e);
        }

        private void Star_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void Star_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Star_1_MouseLeftButtonDown(sender, e);
            star_2.Kind = PackIconKind.Star;
            star_2.Foreground = Brushes.Orange;
        }

        private void Star_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Star_2_MouseLeftButtonDown(sender, e);
            star_3.Kind = PackIconKind.Star;
            star_3.Foreground = Brushes.Orange;
        }

        private void Star_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Star_3_MouseLeftButtonDown(sender, e);
            star_4.Kind = PackIconKind.Star;
            star_4.Foreground = Brushes.Orange;
        }

        private void Star_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Star_4_MouseLeftButtonDown(sender, e);
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
