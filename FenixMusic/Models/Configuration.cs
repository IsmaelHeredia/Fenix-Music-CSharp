using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixMusic
{
    class Configuration
    {
        int id;
        int hotkeys;
        string directory;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Hotkeys
        {
            get
            {
                return hotkeys;
            }

            set
            {
                hotkeys = value;
            }
        }

        public string Directory
        {
            get
            {
                return directory;
            }

            set
            {
                directory = value;
            }
        }
    }
}
