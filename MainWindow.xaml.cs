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

//Meili Zheng;
//122_Final;
//3/22/2023;

namespace _122_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creat list for artpiece and flowdocument;
        List<ArtPiece> artPieces = new List<ArtPiece>();        
        FlowDocument fdDisplay = new FlowDocument();
       
        public MainWindow()
        {
            InitializeComponent();
            //call Flowdocument;
            Flowdocument();            
        } 
        
        private void btDisplayImage_Click(object sender, RoutedEventArgs e)
        {
            //creat file path;
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
            //creat the redio box. 
            string artstyle = "";
            string artInfo = StringFromRichTextBox(rtbBody);
            //use bool to see which redio box user chose;
            bool experessionism = rbExpressionism.IsChecked.Value;
            bool pressionism = rbmpressionsim.IsChecked.Value;
            bool surrealism = rbSurrealism.IsChecked.Value;
            bool neoclassicism = rbNeoclassicism.IsChecked.Value;
            //use if and else to give a value to the variable. if use choose either of them give the name to artstyle; else threw a message box.
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
                              
            //call ArtPices class
            ArtPiece art = new ArtPiece(txtArtName.Text, txtArtist.Text, artInfo, txtFilePath.Text, artstyle, DateTime.Parse(dtpSelectTime.Text));
            artPieces.Add(art);

            //give vaule to rich text box;
            rtbDisplay.Text = $"Artiest: {txtArtist.Text} \n created an art: {txtArtName.Text} \n  art style: {artstyle}\n on: {DateTime.Parse(dtpSelectTime.Text)} \n at: {txtFilePath.Text} \n with detailed info: {artInfo}";
            //give vaule to list box view;
            lbvDisplay.ItemsSource = artPieces;
            //refresh the list box view;
            lbvDisplay.Items.Refresh();
            //call flowdocument method;
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
            //creat a method format the text in rich text box.
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
            //if user selected the information that showed on the list box view. transfer the information that user secleted to the corresponding text box.
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
            // transfer the art style information to redio box from the list box view that the user selected;
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