using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixMusic
{
    class Station
    {
        int id;
        string name;
        string link;
        string categories;

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

        public string Categories
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }
    }
}
