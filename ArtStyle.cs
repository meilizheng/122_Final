using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _122_Final
{
    public class Artstyle
    {
        string experessionism;
        string pressionism;
        string surrealism;
        string neoclassicism;

        public Artstyle(string experessionism, string pressionism, string surrealism, string neoclassicism)
        {
            this.experessionism = experessionism;
            this.pressionism = pressionism;
            this.surrealism = surrealism;
            this.neoclassicism = neoclassicism;
        }

        public string Experessionism { get => experessionism; set => experessionism = value; }
        public string Pressionism { get => pressionism; set => pressionism = value; }
        public string Surrealism { get => surrealism; set => surrealism = value; }
        public string Neoclassicism { get => neoclassicism; set => neoclassicism = value; }
    }
}
