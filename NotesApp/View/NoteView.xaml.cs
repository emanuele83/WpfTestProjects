using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// Interaction logic for NoteView.xaml
    /// </summary>
    public partial class NoteView : Window
    {
        // not possible to use speech recogn in WIN 7....
        //SpeechRecognitionEngine speech;
        public NoteView()
        {
            InitializeComponent();

            // not possible to use speech recogn in WIN 7....
            //var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
            //                     where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
            //                     select r).FirstOrDefault();
            //speech = new SpeechRecognitionEngine(currentCulture);

            //GrammarBuilder builder = new GrammarBuilder();
            //builder.AppendDictation();
            //Grammar grammar = new Grammar(builder);

            //speech.LoadGrammar(grammar);
            //speech.SetInputToDefaultAudioDevice();
            //speech.SpeechRecognized += Speech_SpeechRecognized;

            fontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontSizeComboBox.ItemsSource = new List<double> { 8, 9, 10, 11, 12, 16, 20 };
        }

        //private void Speech_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    var recognizedText = e.Result.Text;
        //    noteText.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
        //}

        //bool isRecognizing = false;
        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            //if (!isRecognizing)
            //{
            //    speech.RecognizeAsync(RecognizeMode.Multiple);
            //    isRecognizing = true;
            //}
            //else
            //{
            //    speech.RecognizeAsyncStop();
            //    isRecognizing = false;
            //}
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if(App.UserId == 0)
            {
                LoginView loginView = new LoginView();
                loginView.ShowDialog();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NoteText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            PopulateStatusBarInfo();

            var selectedTextFontWeight = noteText.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (selectedTextFontWeight != DependencyProperty.UnsetValue) && (selectedTextFontWeight.Equals(FontWeights.Bold));

            var selectedTextDecoration = noteText.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlinedButton.IsChecked = (selectedTextDecoration != DependencyProperty.UnsetValue) && (selectedTextDecoration.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = noteText.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (noteText.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void NoteText_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateStatusBarInfo();
        }

        private void PopulateStatusBarInfo()
        {
            var characters = new TextRange(noteText.Document.ContentStart, noteText.Document.ContentEnd).Text.Length;
            var selectedCharacters = new TextRange(noteText.Selection.Start, noteText.Selection.End).Text.Length;

            statusTextBlock.Text = $"Document: {characters} characters. Selection: {selectedCharacters} characters";
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            bool boldChecked = (sender as ToggleButton).IsChecked ?? false;
            noteText.Selection.ApplyPropertyValue(Inline.FontWeightProperty, boldChecked ? FontWeights.Bold : FontWeights.Normal);
        }

        private void UnderlinedButton_Click(object sender, RoutedEventArgs e)
        {
            bool underlinedChecked = (sender as ToggleButton).IsChecked ?? false;
            if (underlinedChecked)
            {
                noteText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                TextDecorationCollection textDecorations;
                (noteText.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                noteText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(fontFamilyComboBox.SelectedItem != null)
            {
                noteText.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

        private void FontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            noteText.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }
    }
}
