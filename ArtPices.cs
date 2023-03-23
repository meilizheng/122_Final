using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _122_Final
{
    public class ArtPiece
    {
        DateTime _date;
        string _name;
        string _artist;
        string _body;
        string _filePath;
        BitmapImage _art;
        string _artStyle;

        public ArtPiece(string name, string artist, string body, string filePath, string artStyle, DateTime date)
        {
            _name = name;
            _artist = artist;
            _body = body;
            _filePath = filePath;
            _artStyle = artStyle;
            _date = date;
            _art = GenerateBitMap(filePath);
        }

        public string Name
        { 
            get { return _name; }
            set {  _name = value; }
        }

        public string Artist
        { 
            get { return _artist; }
            set { _artist = value; }
        }

        public string Body
        { 
            get { return _body; }
            set
            {
                _body = value;
            }
        }

        public string Year
        {
            get { return _date.Year.ToString(); }
        }

        private BitmapImage GenerateBitMap(string filePath)
        {
            BitmapImage bitImage = new BitmapImage();

            bitImage.BeginInit();
            bitImage.UriSource = new Uri(filePath);
            bitImage.EndInit();
            return bitImage; ;
        }
    }
}
