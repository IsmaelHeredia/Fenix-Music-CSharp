// Fenix Music 1.3
// Copyright © Ismael Heredia 2022

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
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace FenixMusic
{
    public partial class FormHome : Telerik.WinControls.UI.RadForm
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        DataAccess dataAccess = new DataAccess();
        DataConfiguration dataConfiguration = new DataConfiguration();
        Helper helper = new Helper();
        public string database_name;
        public string program_title;
        public WMPLib.IWMPPlaylist playlist;
        public bool repeat = false;
        public bool ended = false;
        public bool playlist_ended = false;
        FormStation formStation = new FormStation(null,0);

        public FormHome()
        {
            InitializeComponent();
            miEditStation.Click += miEditStation_Click;
            miDeleteStation.Click += miDeleteStation_Click;
            RadMessageBox.SetThemeName("VisualStudio2012Dark");
            database_name = System.Configuration.ConfigurationManager.AppSettings["database_name"];
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];
        }

        // Functions

        private void ClearTemporaryPlaylists()
        {
            string mymusic_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            ArrayList dirs = new ArrayList();

            dirs.Add(mymusic_folder + "/Playlists");
            dirs.Add(mymusic_folder + "/Listas de reproducción");

            foreach (string dir in dirs)
            {
                if (Directory.Exists(dir))
                {
                    string[] files = System.IO.Directory.GetFiles(dir, "*.wpl");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        private void generatePlaylists(bool op_loadPlaylist)
        {
            ClearTemporaryPlaylists();

            axWindowsMediaPlayer.Ctlcontrols.stop();

            string directoryToScan = txtDirectoryToScan.Text;

            foreach (string playlist in Directory.GetFiles(directoryToScan, "*.m3u"))
            {
                File.Delete(playlist);
            }

            foreach (string dir in Directory.GetDirectories(directoryToScan))
            {
                string playlist_name = new DirectoryInfo(dir).Name; // Filtro
                string playlist_file = directoryToScan + "/" + playlist_name + ".m3u";

                if (playlist_name.ToLower().Contains(txtSearchPlaylist.Text.ToLower())) // Filtra playlists
                {
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
                        string song_name = Path.GetFileNameWithoutExtension(song);
                        string ext = new FileInfo(song).Extension;
                        if (song_name.ToLower().Contains(txtSearchSong.Text.ToLower())) // Filtra canciones
                        {
                            if (ext == ".mp3")
                            {
                                tw.WriteLine(song);
                            }
                        }
                    }

                    tw.Close();

                }
            }

            if (op_loadPlaylist == true)
            {
                loadPlaylists(directoryToScan);
            }
        }

        private void loadPlaylists(string directoryToScan)
        {
            lvPlaylists.Items.Clear();
            lvSongs.Items.Clear();
            lvStations.Items.Clear();

            if (txtSearchPlaylist.Text == "")
            {
                ListViewDataItem item_all = new ListViewDataItem();
                item_all.SubItems.Add("All");
                lvPlaylists.Items.Add(item_all);
            }

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

            gbPlaylists.Text = "Playlists : " + lvPlaylists.Items.Count + " found";

            lblStatus.Text = "[+] Music loaded";
            this.Refresh();
        }

        public void loadStations()
        {
            lvStations.Items.Clear();
            if (File.Exists(Path.GetFullPath(database_name)))
            {
                DataStation ds = new DataStation();
                lvStations.BeginUpdate();
                ArrayList listStations = ds.List(txtSearchStation.Text);
                foreach (Station station in listStations)
                {
                    int id_station = station.Id;
                    string name = station.Name;
                    string link = station.Link;
                    string categories = station.Categories;
                    ListViewDataItem item = new ListViewDataItem();
                    item.SubItems.Add(id_station);
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
            }
        }

        private void loadSongs(string directoryToScan)
        {
            lvSongs.Items.Clear();

            string name = lvPlaylists.SelectedItem[0].ToString(); // carpeta para argumento
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
                    string song_name = Path.GetFileNameWithoutExtension(song);

                    if (song_name.ToLower().Contains(txtSearchSong.Text.ToLower())) // Filtra canciones
                    {
                        media = axWindowsMediaPlayer.newMedia(song);
                        playlist.appendItem(media);

                        ListViewDataItem item = new ListViewDataItem();
                        item.SubItems.Add(song);
                        item.SubItems.Add(song_name);
                        lvSongs.Items.Add(item);
                    }
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

        private void stop_player()
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        public void sendStatus(string text)
        {
            lblStatus.Text = text;
            ssStatus.LayoutManager.UpdateLayout();
            ssStatus.Refresh();
        }

        // End of functions

        private void FormHome_Load(object sender, EventArgs e)
        {
            string directory_music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
           
            if (!File.Exists(Path.GetFullPath(database_name)))
            {
                dataAccess.createDB();

                Configuration new_configuration = new Configuration();
                new_configuration.Ask_update_playlist = 0;
                new_configuration.Hotkeys = 0;
                new_configuration.Directory = directory_music;

                dataConfiguration.Add(new_configuration);

                RadMessageBox.Show("Database created", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }

            Configuration configuration = dataConfiguration.Get(1);

            int ask_update_playlist = configuration.Ask_update_playlist;
            int hotkeys = configuration.Hotkeys;
            string directory = configuration.Directory;

            ClearTemporaryPlaylists();

            txtDirectoryToScan.Text = directory;

            if (ask_update_playlist == 1)
            {
                cbAskUpdatePlaylist.Checked = true;
            }

            if (hotkeys == 1)
            {
                cbEnableHotkeys.Checked = true;
            }

            axWindowsMediaPlayer.settings.volume = 100;

            generatePlaylists(true);
            loadStations();
        }

        private void lvPlaylists_DoubleClick(object sender, EventArgs e)
        {
            if (lvPlaylists.SelectedItem != null)
            {
                ClearTemporaryPlaylists();

                string directoryToScan = txtDirectoryToScan.Text;

                loadSongs(directoryToScan);
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generatePlaylists(true);

            RadMessageBox.Show("Playlist generated", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

            lblStatus.Text = "[+] Playlist generated";
            this.Refresh();
        }

        private void repeat_song()
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

        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            repeat_song();
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.fullScreen = true;
        }

        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 10) // Ready
            {
                if (playlist_ended == true)
                {
                    ended = true;
                }
            }
            else if (e.newState == 1) // Stopped
            {
                if (playlist_ended == true && ended == true)
                {
                    playlist_ended = false;
                    axWindowsMediaPlayer.Ctlcontrols.play();
                }
            }
            else if (e.newState == 8) // Song End
            {
                ended = true;

                int song_index = lvSongs.SelectedIndex;
                int songs_count = lvSongs.Items.Count - 1;
                if (song_index == songs_count)
                {
                    playlist_ended = true;

                    axWindowsMediaPlayer.Ctlcontrols.play();
                }
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
                string stream_url = lvStations.SelectedItem[2].ToString();
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

        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDirectoryToScan.Text = dialog.SelectedPath;
            }
        }

        private void btnShowHotkeys_Click(object sender, EventArgs e)
        {
            string message = "F5 - Stop\n\nF6 - Previous\n\nF7 - Play / Pause\n\nF8 - Next\n\nF9 - Repeat";
            RadMessageBox.Show(message, program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            formStation = new FormStation(this,0);
            formStation.Show();
        }

        private void cbAskUpdatePlaylist_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            Configuration configuration = dataConfiguration.Get(1);
            if (cbAskUpdatePlaylist.Checked == true)
            {
                configuration.Ask_update_playlist = 1;
            } else
            {
                configuration.Ask_update_playlist = 0;
            }
            dataConfiguration.Update(configuration);
            MessageBox.Show("Cb Playlist");
        }

        private void cbEnableHotkeys_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            Configuration configuration = dataConfiguration.Get(1);
            if (cbEnableHotkeys.Checked == true)
            {
                configuration.Hotkeys = 1;
            }
            else
            {
                configuration.Hotkeys = 0;
            }
            dataConfiguration.Update(configuration);
            MessageBox.Show("Cb Hotkeys");
        }

        private void btnSavePlaylistDirectory_Click(object sender, EventArgs e)
        {
            Configuration configuration = dataConfiguration.Get(1);
            configuration.Directory = txtDirectoryToScan.Text;
            dataConfiguration.Update(configuration);
            MessageBox.Show("save playlist directory");
        }

        private void txtSearchPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                generatePlaylists(true);

                if (txtSearchPlaylist.Text != "")
                {
                    lblStatus.Text = "[+] Playlists with text \"" + txtSearchPlaylist.Text + "\" loaded";
                    this.Refresh();
                }
            }
        }

        private void txtSearchSong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                generatePlaylists(false);

                string directoryToScan = txtDirectoryToScan.Text;

                loadSongs(directoryToScan);

                if (txtSearchSong.Text != "")
                {
                    lblStatus.Text = "[+] Songs with text \"" + txtSearchSong.Text + "\" loaded";
                    this.Refresh();
                }
            }
        }

        private void lvStations_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvStations.SelectedIndex > -1)
                {
                    cmStationOptions.Show(Cursor.Position);
                }
            }
        }

        private void miEditStation_Click(object sender, EventArgs e)
        {
            if (!formStation.Visible)
            {
                stop_player();
                var id_station = Convert.ToInt32(lvStations.SelectedItem[0]);
                formStation = new FormStation(this, id_station);
                formStation.Show();
            }
        }

        private void miDeleteStation_Click(object sender, EventArgs e)
        {
            DialogResult ds = RadMessageBox.Show(this, "Are you sure ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (ds.ToString() == "Yes")
            {
                stop_player();

                var id_station = Convert.ToInt32(lvStations.SelectedItem[0]);
                DataStation dataStation = new DataStation();
                if (dataStation.Delete(id_station))
                {
                    RadMessageBox.Show("Station deleted", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    RadMessageBox.Show("Error deleting station", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                }
                loadStations();
            }
        }

        private void btnImportStations_Click(object sender, EventArgs e)
        {
            stop_player();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Title = "Open JSON File";
            openFileDialog.DefaultExt = "json";
            openFileDialog.Filter = "JSON File (.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sendStatus("[+] Importing ...");
                string json_file = openFileDialog.FileName;
                ArrayList listStations = new ArrayList();
                string json_content = File.ReadAllText(json_file);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json_content, (typeof(DataTable)));
                foreach (DataRow row in dt.Rows)
                {
                    Station station = new Station();
                    station.Name = Convert.ToString(row["name"]);
                    station.Link = Convert.ToString(row["link"]);
                    station.Categories = Convert.ToString(row["categories"]);
                    listStations.Add(station);
                }
                DataStation ds = new DataStation();
                foreach (Station station in listStations)
                {
                    ds.Add(station);
                }
                loadStations();
                sendStatus("[+] Done");
                RadMessageBox.Show("Table imported", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnExportStations_Click(object sender, EventArgs e)
        {
            stop_player();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON File (.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json_file = saveFileDialog.FileName;
                if (File.Exists(json_file))
                {
                    File.Delete(json_file);
                }
                DataAccess da = new DataAccess();
                sendStatus("[+] Exporting ...");
                DataTable dt = da.loadStationTable();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt, Formatting.Indented);
                StreamWriter sw = File.CreateText(json_file);
                sw.Write(JSONString);
                sw.Close();
                sendStatus("[+] Done");
                RadMessageBox.Show("Table exported", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnValidateStations_Click(object sender, EventArgs e)
        {
            stop_player();
            ArrayList listStationsFail = new ArrayList();
            string message = "";
            foreach (ListViewDataItem item in lvStations.Items)
            {
                Station station = new Station();
                station.Id = Convert.ToInt32(item[0]);
                station.Name = item[1].ToString();
                station.Link = item[2].ToString();

                sendStatus("[+] Checking station : " + station.Name + " ...");

                if (!helper.check_url(station.Link))
                {
                    listStationsFail.Add(station);
                    message += "Radio name : " + station.Name + "\n";
                }
            }
            if (listStationsFail.Count > 0)
            {
                RadMessageBox.Show(message, program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                DialogResult ds = RadMessageBox.Show(this, "You want delete this stations ?", program_title, MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (ds.ToString() == "Yes")
                {
                    DataStation dataStation = new DataStation();
                    foreach (Station station in listStationsFail)
                    {
                        dataStation.Delete(station.Id);
                    }
                }
            }
            else
            {
                RadMessageBox.Show("All stations works", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
            }
            loadStations();
            sendStatus("[+] Done");
        }

        private void tmDetectHotkeys_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.F5) == -32767)
            {
                sendStatus("[+] Hotkey stop executed");
                axWindowsMediaPlayer.Ctlcontrols.stop();
            }
            else if (GetAsyncKeyState(Keys.F6) == -32767)
            {
                sendStatus("[+] Hotkey previous executed");
                axWindowsMediaPlayer.Ctlcontrols.previous();
            }
            else if (GetAsyncKeyState(Keys.F7) == -32767)
            {
                if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    sendStatus("[+] Hotkey pause executed");
                    axWindowsMediaPlayer.Ctlcontrols.pause();
                }
                else
                {
                    sendStatus("[+] Hotkey play executed");
                    axWindowsMediaPlayer.Ctlcontrols.play();
                }
            }
            else if (GetAsyncKeyState(Keys.F8) == -32767)
            {
                sendStatus("[+] Hotkey next executed");
                axWindowsMediaPlayer.Ctlcontrols.next();
            }
            else if (GetAsyncKeyState(Keys.F9) == -32767)
            {
                sendStatus("[+] Hotkey repeat executed");
                repeat_song();
            }
        }

        private void btnHotkeyControl_Click(object sender, EventArgs e)
        {
            if (btnHotkeyControl.Text == "Enable")
            {
                tmDetectHotkeys.Enabled = true;
                btnHotkeyControl.Text = "Disable";
            }
            else
            {
                tmDetectHotkeys.Enabled = false;
                btnHotkeyControl.Text = "Enable";
            }
        }
    }
}