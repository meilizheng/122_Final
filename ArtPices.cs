using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

//Meili Zheng;
//122_Final;
//3/22/2023;

namespace _122_Final
{
    public class ArtPiece
    {
        //creat the field;
        DateTime _date;
        string _name;
        string _artist;
        string _body;
        string _filePath;
        BitmapImage _art;
        string _artStyle;

        //creat the constructor;
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

        //creat the property;
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

        public string FilePath
        {
            get { return _filePath; }
            set { value = _filePath; }
        }

        public string Year
        {
            get { return _date.Year.ToString(); }
        }

        public DateTime Date
        { 
            get { return _date; }
            set { value = _date; }
        }

        public string ArtSytle
        { 
            get { return _artStyle; }
            set { _artStyle = value; }
        }

        //creat the generateBitMap method;
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
