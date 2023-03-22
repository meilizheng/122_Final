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
            Preload();
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
            ArtPiece art = new ArtPiece(txtArtName.Text, txtArtist.Text, String.Empty, txtFilePath.Text, String.Empty, DateTime.Parse(dtpSelectTime.Text));

            string artName = txtArtName.Text;
            string artist = txtArtist.Text;
            string artinfor = txtArtInfor.Text;
            string artinfo = artName + " " + artist + " " + artinfor;
            rtbDisplay.Text += artinfo;
        }
    }
}