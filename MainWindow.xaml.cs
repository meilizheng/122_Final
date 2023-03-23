using Microsoft.Win32;
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

        public void Preload ()
        {
            string artName = txtArtName.Text;
            string artist = txtArtist.Text;
            string artinfor = txtArtInfor.Text;
            string artinfo = artName + " " + artist + " " + artinfor;
            string filepath = txtFilePath.Text;
            
            artPieces.Add(new ArtPiece(artName, artist, artinfo, filepath, string.Empty, DateTime.Now)); 
            lbvDisplay.ItemsSource = artPieces;
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
            string name = txtArtName.Text;
            FlowDocument fdDisplay = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run(name);
            r.FontWeight = FontWeights.Bold;
            r.Foreground = new SolidColorBrush(Colors.Cyan);
            r.FontSize = 18;
            p.Inlines.Add(r);
            fdDisplay.Blocks.Add(p);
            rtbInformationDisplay.Document = fdDisplay;
        } 
    }
}