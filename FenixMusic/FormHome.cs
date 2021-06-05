// Fenix Music 1.0
// Copyright © Ismael Heredia 2021

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FenixMusic
{
    public partial class FormHome : Telerik.WinControls.UI.RadForm
    {
        public string database_name;
        public string program_title;
        public WMPLib.IWMPPlaylist playlist;
        public bool repeat = false;
        public bool ended = false;

        public FormHome()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("VisualStudio2012Dark");
            database_name = System.Configuration.ConfigurationManager.AppSettings["database_name"];
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];
        }

        private void ClearTemporaryPlaylists()
        {
            string mymusic_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            ArrayList dirs = new ArrayList();

            dirs.Add(mymusic_folder + "/Playlists");
            dirs.Add(mymusic_folder + "/Listas de reproducción");

            foreach(string dir in dirs)
            {
                if (Directory.Exists(dir))
                {
                    string[] files = System.IO.Directory.GetFiles(dir, "*.wpl");
                    foreach(string file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        private void loadTables()
        {
            lvPlaylists.Items.Clear();
            lvSongs.Items.Clear();
            lvStations.Items.Clear();

            string directoryToScan = txtDirectoryToScan.Text;

            ListViewDataItem item_all = new ListViewDataItem();
            item_all.SubItems.Add("All");
            lvPlaylists.Items.Add(item_all);

            lvPlaylists.BeginUpdate();

            foreach (string playlist in Directory.GetFiles(directoryToScan, "*.m3u"))
            {
                string name = Path.GetFileNameWithoutExtension(playlist);
                ListViewDataItem item = new ListViewDataItem();
                item.SubItems.Add(name);
                lvPlaylists.Items.Add(item);
            }

            lvPlaylists.EndUpdate();

            if (lvPlaylists.SelectedIndex > 0)
            {
                lvPlaylists.SelectedIndex = 0;
            }

            axWindowsMediaPlayer.settings.volume = 100;

            gbPlaylists.Text = "Playlists : " + lvPlaylists.Items.Count + " found";

            string json_file = "stations.json";
            string json_content = File.ReadAllText(json_file);

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json_content, (typeof(DataTable)));

            lvStations.BeginUpdate();

            foreach (DataRow row in dt.Rows)
            {
                string name = Convert.ToString(row["name"]);
                string link = Convert.ToString(row["link"]);
                string categories = Convert.ToString(row["categories"]);

                ListViewDataItem item = new ListViewDataItem();
                item.SubItems.Add(name);
                item.SubItems.Add(link);
                item.SubItems.Add(categories);
                lvStations.Items.Add(item);
            }

            lvStations.EndUpdate();

            if (lvStations.SelectedIndex > 0)
            {
                lvStations.SelectedIndex = 0;
            }

            gbStations.Text = "Stations : " + lvStations.Items.Count + " found";

            lblStatus.Text = "[+] Music loaded";
            this.Refresh();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            ClearTemporaryPlaylists();

            string directory_music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            txtDirectoryToScan.Text = directory_music;

            loadTables();

            DialogResult ds_gen = RadMessageBox.Show(this, "Do you want update playlists with directory : " + directory_music + " ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (ds_gen.ToString() == "Yes")
            {
                generatePlaylists();
            }
        }

        private void lvPlaylists_DoubleClick(object sender, EventArgs e)
        {
            if (lvPlaylists.SelectedItem != null)
            {
                ClearTemporaryPlaylists();

                lvSongs.Items.Clear();

                string directoryToScan = txtDirectoryToScan.Text;
                string name = lvPlaylists.SelectedItem[0].ToString();
                string fullpath = directoryToScan + "/" + name + ".m3u";

                if (name == "All")
                {
                    DirectoryInfo info = new DirectoryInfo(directoryToScan);
                    FileInfo[] files = info.GetFiles("*.mp3", SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();

                    ArrayList songs = new ArrayList();

                    foreach (FileInfo file in files)
                    {
                        songs.Add(file.FullName);
                    }

                    songs.Reverse();

                    playlist = axWindowsMediaPlayer.playlistCollection.newPlaylist("MyPlaylist");
                    WMPLib.IWMPMedia media;

                    lvSongs.BeginUpdate();

                    foreach (string song in songs)
                    {
                        media = axWindowsMediaPlayer.newMedia(song);
                        playlist.appendItem(media);
                        string song_name = Path.GetFileNameWithoutExtension(song);
                        ListViewDataItem item = new ListViewDataItem();
                        item.SubItems.Add(song);
                        item.SubItems.Add(song_name);
                        lvSongs.Items.Add(item);
                    }

                    lvSongs.EndUpdate();

                    axWindowsMediaPlayer.settings.autoStart = false;
                    axWindowsMediaPlayer.currentPlaylist = playlist;
                }
                else
                {
                    playlist = axWindowsMediaPlayer.playlistCollection.newPlaylist("MyPlaylist");
                    WMPLib.IWMPMedia media;

                    var songs = File.ReadLines(fullpath);

                    lvSongs.BeginUpdate();

                    foreach (string song in songs)
                    {
                        media = axWindowsMediaPlayer.newMedia(song);
                        playlist.appendItem(media);
                        string song_name = Path.GetFileNameWithoutExtension(song);
                        ListViewDataItem item = new ListViewDataItem();
                        item.SubItems.Add(song);
                        item.SubItems.Add(song_name);
                        lvSongs.Items.Add(item);
                    }

                    lvSongs.EndUpdate();

                    axWindowsMediaPlayer.settings.autoStart = false;
                    axWindowsMediaPlayer.currentPlaylist = playlist;
                }

                if (lvSongs.SelectedIndex > 0)
                {
                    lvSongs.SelectedIndex = 0;
                }

                gbSongs.Text = "Songs : " + lvSongs.Items.Count + " found";
            }
        }

        private void lvSongs_DoubleClick(object sender, EventArgs e)
        {
            if (lvSongs.SelectedItem != null)
            {
                int song_index = lvSongs.SelectedIndex;

                WMPLib.IWMPMedia media = axWindowsMediaPlayer.currentPlaylist.get_Item(song_index);
                axWindowsMediaPlayer.Ctlcontrols.playItem(media);
                axWindowsMediaPlayer.settings.autoStart = true;
            }
        }

        private void generatePlaylists()
        {
            string directoryToScan = txtDirectoryToScan.Text;

            foreach (string playlist in Directory.GetFiles(directoryToScan, "*.m3u"))
            {
                File.Delete(playlist);
            }

            foreach (string dir in Directory.GetDirectories(directoryToScan))
            {
                string playlist_name = new DirectoryInfo(dir).Name;
                string playlist_file = directoryToScan + "/" + playlist_name + ".m3u";

                DirectoryInfo info = new DirectoryInfo(dir);

                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

                ArrayList songs = new ArrayList();

                foreach (FileInfo file in files)
                {
                    songs.Add(file.FullName);
                }

                songs.Reverse();

                TextWriter tw = new StreamWriter(playlist_file);

                foreach (string song in songs)
                {
                    string ext = new FileInfo(song).Extension;
                    if (ext == ".mp3")
                    {
                        tw.WriteLine(song);
                    }
                }

                tw.Close();
            }

            loadTables();

            RadMessageBox.Show("Playlist generated", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

            lblStatus.Text = "[+] Playlist generated";
            this.Refresh();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generatePlaylists();
        }

        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            if (repeat == false)
            {
                repeat = true;
                btnPlayMode.Text = "Repeat song : OFF";
            }
            else
            {
                repeat = false;
                btnPlayMode.Text = "Repeat song : ON";
            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.fullScreen = true;
        }

        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8) // Song End
            {
                ended = true;
            }
            else if (e.newState == 3) // Song start
            {
                if (repeat == true && ended == true)
                {
                    string name = lvSongs.SelectedItem[0].ToString();

                    int song_index = lvSongs.SelectedIndex;
                    WMPLib.IWMPMedia media = axWindowsMediaPlayer.currentPlaylist.get_Item(song_index);
                    axWindowsMediaPlayer.Ctlcontrols.playItem(media);
                    axWindowsMediaPlayer.settings.autoStart = true;
                }
                else
                {
                    string fullpath_play = axWindowsMediaPlayer.currentMedia.sourceURL;
                    foreach (ListViewDataItem item in lvSongs.Items)
                    {
                        string fullpath = item[0].ToString();
                        if (fullpath == fullpath_play)
                        {
                            lvSongs.SelectedItem = item;
                        }
                    }
                }

                SongInfo songInfo = new SongInfo();

                string song_file = axWindowsMediaPlayer.currentMedia.sourceURL;

                if (File.Exists(song_file))
                {
                    Bitmap bm = songInfo.Get(song_file).Image;

                    if (bm != null)
                    {
                        pbCover.Image = bm;
                    }
                    else
                    {
                        pbCover.Image = FenixMusic.Properties.Resources.fenix;
                    }
                }

                ended = false;
            }
        }

        private void lvStations_DoubleClick(object sender, EventArgs e)
        {
            if (lvStations.SelectedItem != null)
            {
                string stream_url = lvStations.SelectedItem[1].ToString();
                axWindowsMediaPlayer.URL = stream_url;
            }
        }

        private void FormHome_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon.Visible = true;
            }
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ds = RadMessageBox.Show(this, "Are you sure ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (ds.ToString() != "Yes")
            {
                e.Cancel = true;
                this.Activate();
            }
            else
            {
                ClearTemporaryPlaylists();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}