using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FenixMusic
{
    class Song
    {
        string title;
        string artist;
        string album;
        string year;
        string genre;
        string time;
        Bitmap image;
        string path;
        string creation_date;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Artist
        {
            get
            {
                return artist;
            }

            set
            {
                artist = value;
            }
        }

        public string Album
        {
            get
            {
                return album;
            }

            set
            {
                album = value;
            }
        }

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public string Creation_date
        {
            get
            {
                return creation_date;
            }

            set
            {
                creation_date = value;
            }
        }
    }
}
