using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.IO;
using System.Drawing;

namespace FenixMusic
{
    class SongInfo
    {
        public string clearName(string name)
        {
            ArrayList characters = new ArrayList() { "@", "$", "%", "&", "\\", "/", ":", "*", "?" };
            foreach (string character in characters)
            {
                name = name.Replace(character, "");
            }
            return name;
        }

        public Song Get(string fullpath)
        {
            DateTime dt = File.GetCreationTime(fullpath);

            string datetime = dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.ToLongTimeString();

            TagLib.File file = TagLib.File.Create(fullpath);

            string title = file.Tag.Title;
            string artist = file.Tag.FirstPerformer;
            string album = file.Tag.Album;
            string year = file.Tag.Year.ToString();
            string genre = file.Tag.FirstGenre;

            WindowsMediaPlayerClass wmp = new WindowsMediaPlayerClass();
            IWMPMedia mediaInformation = wmp.newMedia(fullpath);

            string duration = mediaInformation.durationString;

            if (title == null || title == "")
            {
                title = Path.GetFileNameWithoutExtension(fullpath);
            }

            if (artist == null || artist == "")
            {
                artist = "Artist Unknown";
            }

            if (album == null || album == "")
            {
                album = "Album Unknown";
            }

            if (year == null || year == "0")
            {
                year = "Year Unknown";
            }

            if (genre == null || genre == "")
            {
                genre = "Genre Unknown";
            }

            if (duration == null || duration == "")
            {
                duration = "Time Unknown";
            }

            Bitmap image = null;

            var coverStream = new MemoryStream();

            var cover = file.Tag.Pictures.FirstOrDefault();

            if (cover != null)
            {
                try
                {
                    byte[] coverData = cover.Data.Data;
                    coverStream.Write(coverData, 0, Convert.ToInt32(coverData.Length));
                    var bitmapCover = new Bitmap(coverStream, false);
                    coverStream.Dispose();
                    Bitmap newBitmapCover = new Bitmap(bitmapCover);
                    bitmapCover.Dispose();
                    bitmapCover = null;
                    image = newBitmapCover;
                }
                catch
                {
                    image = null;
                }
            }

            Song song = new Song();
            song.Title = title;
            song.Artist = artist;
            song.Album = album;
            song.Year = year;
            song.Genre = genre;
            song.Time = duration;

            song.Image = image;
            song.Path = fullpath;
            song.Creation_date = datetime;

            return song;
        }
    }
}
