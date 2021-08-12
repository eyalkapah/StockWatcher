using System.Windows;
using System.Windows.Controls;

namespace StockWatcher.CustomControls
{
    public class PasswordInputWithValidation : Control
    {
        private PasswordBox _passwordBox;
        private const string PasswordBoxPart = "PART_PasswordBox";

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(string), typeof(PasswordInputWithValidation),
            new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(PasswordInputWithValidation), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(
            "ErrorText", typeof(string), typeof(PasswordInputWithValidation), new PropertyMetadata(default(string)));

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }

        static PasswordInputWithValidation()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PasswordInputWithValidation),
                new FrameworkPropertyMetadata(typeof(PasswordInputWithValidation)));
        }

        public override void OnApplyTemplate()
        {
            _passwordBox = GetTemplateChild(PasswordBoxPart) as PasswordBox;

            if (_passwordBox != null)
                _passwordBox.PasswordChanged += PasswordBoxOnPasswordChanged;
        }

        private void PasswordBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = _passwordBox.Password;
        }
    }
}