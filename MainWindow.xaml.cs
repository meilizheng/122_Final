using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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
using System.Xml.Linq;

namespace _122_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ArtPiece> artPieces = new List<ArtPiece>();        
        FlowDocument fdDisplay = new FlowDocument();
       
        public MainWindow()
        {
            InitializeComponent();
            Flowdocument();            
        } 
        
        private void btDisplayImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Secelt a picture:";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                ImageDisplay.Source = new BitmapImage(new Uri(op.FileName));
                txtFilePath.Text = op.FileName;
            }
        }
        private void btSubmitArtInforation_Click(object sender, RoutedEventArgs e)
        {
            string artstyle = "";
            string artInfo = StringFromRichTextBox(rtbBody);
            bool experessionism = rbExpressionism.IsChecked.Value;
            bool pressionism = rbmpressionsim.IsChecked.Value;
            bool surrealism = rbSurrealism.IsChecked.Value;
            bool neoclassicism = rbNeoclassicism.IsChecked.Value;
            if (experessionism == true)
            {
                artstyle = "Experessionism";
            }
            else if (pressionism == true)
            {
                artstyle = "Pressionism";
            }
            else if (surrealism == true)
            {
                artstyle = "Surrealism";
            }
            else if (neoclassicism == true)
            {
                artstyle = "Neoclassicism";
            }
            else
            {
                MessageBox.Show("Please select the Art style.");
            }
                              

            ArtPiece art = new ArtPiece(txtArtName.Text, txtArtist.Text, artInfo, txtFilePath.Text, artstyle, DateTime.Parse(dtpSelectTime.Text));
            artPieces.Add(art);

            rtbDisplay.Text = $"Artiest: {txtArtist.Text} \n created an art: {txtArtName.Text} \n  art style: {artstyle}\n on: {DateTime.Parse(dtpSelectTime.Text)} \n at: {txtFilePath.Text} \n with detailed info: {artInfo}";

            lbvDisplay.ItemsSource = artPieces;
            lbvDisplay.Items.Refresh();
            Flowdocument();
        }

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        public void Flowdocument()
        {
            FlowDocument fdDisplay = new FlowDocument();
            Paragraph artname = new Paragraph();
            Paragraph artist = new Paragraph();
            Paragraph filepath = new Paragraph();
            Run artName = new Run(txtArtName.Text);
            Run artistrun = new Run(txtArtist.Text);            
            Run filePath = new Run(txtFilePath.Text);
            artName.FontWeight = FontWeights.Bold;
            artName.FontSize = 18;
            artistrun.FontWeight = FontWeights.Bold;
            artistrun.FontSize = 16;            
            filePath.FontWeight = FontWeights.Bold;
            filePath.FontSize = 14;
            artname.Inlines.Add(artName);
            artist.Inlines.Add(artistrun);
            filepath.Inlines.Add(filePath);
            fdDisplay.Blocks.Add(artname);
            fdDisplay.Blocks.Add(artist);
            fdDisplay.Blocks.Add(filepath);
            rtbInformationDisplay.Document = fdDisplay;
        }

        private void lbvDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedArtPiece = (ArtPiece)lbvDisplay.SelectedItem;
            txtArtName.Text = selectedArtPiece.Name;
            txtArtist.Text = selectedArtPiece.Artist;
            txtFilePath.Text = selectedArtPiece.FilePath;
            dtpSelectTime.Text = selectedArtPiece.Date.ToString();
            
            ImageDisplay.Source = new BitmapImage(new Uri(selectedArtPiece.FilePath));
            
            rtbDisplay.Text = $"Artiest: {selectedArtPiece.Name} \n created an art: {selectedArtPiece.Artist} \n  art style: {selectedArtPiece.ArtSytle}\n on: {selectedArtPiece.Date} \n at: {selectedArtPiece.FilePath} \n with detailed info: {selectedArtPiece.Body}";

            rtbBody.Document.Blocks.Clear();
            rtbBody.Document.Blocks.Add(new Paragraph(new Run(selectedArtPiece.Body)));
            rtbInformationDisplay.Document.Blocks.Clear();
            Flowdocument();

            switch (selectedArtPiece.ArtSytle)
            {
                case "Experessionism":
                    rbExpressionism.IsChecked = true;
                    break;
                case "Pressionism":
                    rbmpressionsim.IsChecked = true;
                    break;
                case "Surrealism":
                    rbSurrealism.IsChecked = true;
                    break;
                case "Neoclassicism":
                    rbNeoclassicism.IsChecked = true;
                    break;
                default:
                    break;
            }
        }
    }
}