
using System;
using System.Collections.Generic;
using System.Windows;

namespace MyMailClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private State state;

        private static List<string> recipients;
        public MainWindow()
        {
            recipients = new List<string>();
            state = new State();
            InitializeComponent();
            updateStatus();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.Empty == filter(toText.Text)))
            {
                recipients.Add(toText.Text);
                toBox.Items.Add(toText.Text);
                updateStatus();
            }
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            recipients.Clear();
            toBox.Items.Clear();
            updateStatus();
        }
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string subject = subjectBox.Text;
            string body = bodyBox.Text;

            string recps = string.Join(",", recipients);

            try
            {
                new ToCommand("to").Execute(recps, state);
                new BodyCommand("body").Execute(body, state);
                new SubjectCommand("subject").Execute(subject, state);
                new SendCommand("send").Execute(null, state);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            MessageBox.Show($"{recipients.Count} mails has been sent!");
        }
        private void updateStatus()
        {
            if (recipients.Count > 0)
            {
                statusText.Foreground = System.Windows.Media.Brushes.Green;
                sendButton.Visibility = Visibility.Visible;
            }
            else
            {
                statusText.Foreground = System.Windows.Media.Brushes.Red;
                sendButton.Visibility = Visibility.Hidden;
            }
            statusText.Text = $"Total {recipients.Count} valid mails!";
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var item = toBox.SelectedItem;
            if (item != null)
            {
                toBox.Items.Remove(item);
                recipients.Remove(item.ToString());
                updateStatus();
            }
        }
        private static string filter(string param)
        {

            List<string> validMails = new List<string>(); ;
            var recipients = param.Split(' ', ',');

            foreach (var recipient in recipients)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(recipient);
                    if (!(addr.Address == recipient))
                        throw new Exception($"Invalid mail address: {recipient}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                validMails.Add(recipient);
            }
            return string.Join(",", validMails); ;
        }
    }
}
