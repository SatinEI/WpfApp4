using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplyGradientBackground();
        }
        private void ApplyGradientBackground()
        {
            var gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LightBlue, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LightGreen, 1.0));

            TextBox1.Background = gradientBrush;
            TextBox2.Background = gradientBrush;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            UpdateCloseButtonState();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FontStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedStyle = (FontStyleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selectedStyle)
            {
                case "Стиль 1":
                    SetFontStyle("Spectral", 18, Colors.Purple);
                    UpdateCloseButtonState();
                    break;
                case "Стиль 2":
                    SetFontStyle("Times New Roman", 14, Colors.DarkBlue);
                    UpdateCloseButtonState();
                    break;
                case "Стиль 3":
                    SetFontStyle("Courier New", 16, Colors.DarkRed);
                    UpdateCloseButtonState();
                    break;
                default:
                    break;
            }
        }
        private void SetFontStyle(string fontFamily, double fontSize, Color fontColor)
        {
            TextBox1.FontFamily = new FontFamily(fontFamily);
            TextBox1.FontSize = fontSize;
            TextBox1.Foreground = new SolidColorBrush(fontColor);

            TextBox2.FontFamily = new FontFamily(fontFamily);
            TextBox2.FontSize = fontSize;
            TextBox2.Foreground = new SolidColorBrush(fontColor);
        }

        private void UpdateCloseButtonState()
        {
            CloseButton.IsEnabled = string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text);
        }

        private void OpenButton_MouseEnter(object sender, MouseEventArgs e)
        {

        }

    }

}



