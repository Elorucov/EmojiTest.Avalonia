using Avalonia.Controls;
using NeoSmart.Unicode;
using System.Collections.Generic;
using System.Linq;

namespace EmojiTest {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            fontSize.PropertyChanged += Slider_PropertyChanged;
        }

        private void MainWindow_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            var groupedEmojis = Emoji.Basic.GroupBy(e => e.Group).ToList();
            emojiList.Items = groupedEmojis;
        }

        List<TextBlock> emojiUI = new List<TextBlock>();
        private void TextBlockLoaded(object sender, Avalonia.Interactivity.RoutedEventArgs e) {
            emojiUI.Add((TextBlock)sender);
        }

        private void Slider_PropertyChanged(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e) {
            if (e.Property != Slider.ValueProperty) return;
            foreach (TextBlock tb in emojiUI) {
                tb.FontSize = fontSize.Value;
            }
        }
    }
}