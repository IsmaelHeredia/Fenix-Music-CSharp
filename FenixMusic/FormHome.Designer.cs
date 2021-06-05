namespace FenixMusic
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn7 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn8 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Link");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn9 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Categories");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Fullpath");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name");
            this.visualStudio2012DarkTheme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lblStatus = new Telerik.WinControls.UI.RadLabelElement();
            this.pvpSettings = new Telerik.WinControls.UI.RadPageViewPage();
            this.gbGeneratePlaylist = new Telerik.WinControls.UI.RadGroupBox();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.lblDirectory = new Telerik.WinControls.UI.RadLabel();
            this.txtDirectoryToScan = new Telerik.WinControls.UI.RadTextBox();
            this.pvpStations = new Telerik.WinControls.UI.RadPageViewPage();
            this.gbStations = new Telerik.WinControls.UI.RadGroupBox();
            this.lvStations = new Telerik.WinControls.UI.RadListView();
            this.pvpHome = new Telerik.WinControls.UI.RadPageViewPage();
            this.gbSongs = new Telerik.WinControls.UI.RadGroupBox();
            this.lvSongs = new Telerik.WinControls.UI.RadListView();
            this.gbPlaylists = new Telerik.WinControls.UI.RadGroupBox();
            this.lvPlaylists = new Telerik.WinControls.UI.RadListView();
            this.pvMenu = new Telerik.WinControls.UI.RadPageView();
            this.btnPlayMode = new Telerik.WinControls.UI.RadButton();
            this.btnFullscreen = new Telerik.WinControls.UI.RadButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            this.pvpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbGeneratePlaylist)).BeginInit();
            this.gbGeneratePlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryToScan)).BeginInit();
            this.pvpStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbStations)).BeginInit();
            this.gbStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvStations)).BeginInit();
            this.pvpHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSongs)).BeginInit();
            this.gbSongs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPlaylists)).BeginInit();
            this.gbPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvPlaylists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMenu)).BeginInit();
            this.pvMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFullscreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCover
            // 
            this.pbCover.Image = ((System.Drawing.Image)(resources.GetObject("pbCover.Image")));
            this.pbCover.Location = new System.Drawing.Point(20, 407);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(136, 113);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 4;
            this.pbCover.TabStop = false;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lblStatus});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 543);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(872, 26);
            this.radStatusStrip1.TabIndex = 5;
            this.radStatusStrip1.ThemeName = "VisualStudio2012Dark";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.radStatusStrip1.SetSpring(this.lblStatus, false);
            this.lblStatus.Text = "[+] Done";
            this.lblStatus.TextWrap = true;
            // 
            // pvpSettings
            // 
            this.pvpSettings.Controls.Add(this.gbGeneratePlaylist);
            this.pvpSettings.ItemSize = new System.Drawing.SizeF(52F, 24F);
            this.pvpSettings.Location = new System.Drawing.Point(205, 4);
            this.pvpSettings.Name = "pvpSettings";
            this.pvpSettings.Size = new System.Drawing.Size(624, 365);
            this.pvpSettings.Text = "Settings";
            // 
            // gbGeneratePlaylist
            // 
            this.gbGeneratePlaylist.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbGeneratePlaylist.Controls.Add(this.btnGenerate);
            this.gbGeneratePlaylist.Controls.Add(this.lblDirectory);
            this.gbGeneratePlaylist.Controls.Add(this.txtDirectoryToScan);
            this.gbGeneratePlaylist.HeaderText = "Generate playlist";
            this.gbGeneratePlaylist.Location = new System.Drawing.Point(20, 14);
            this.gbGeneratePlaylist.Name = "gbGeneratePlaylist";
            this.gbGeneratePlaylist.Size = new System.Drawing.Size(593, 134);
            this.gbGeneratePlaylist.TabIndex = 0;
            this.gbGeneratePlaylist.Text = "Generate playlist";
            this.gbGeneratePlaylist.ThemeName = "VisualStudio2012Dark";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(155, 87);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(283, 24);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.ThemeName = "VisualStudio2012Dark";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.Location = new System.Drawing.Point(15, 38);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(61, 18);
            this.lblDirectory.TabIndex = 2;
            this.lblDirectory.Text = "Directory : ";
            this.lblDirectory.ThemeName = "VisualStudio2012Dark";
            // 
            // txtDirectoryToScan
            // 
            this.txtDirectoryToScan.Location = new System.Drawing.Point(82, 34);
            this.txtDirectoryToScan.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtDirectoryToScan.Name = "txtDirectoryToScan";
            // 
            // 
            // 
            this.txtDirectoryToScan.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.txtDirectoryToScan.Size = new System.Drawing.Size(490, 24);
            this.txtDirectoryToScan.TabIndex = 0;
            this.txtDirectoryToScan.ThemeName = "VisualStudio2012Dark";
            // 
            // pvpStations
            // 
            this.pvpStations.Controls.Add(this.gbStations);
            this.pvpStations.ItemSize = new System.Drawing.SizeF(52F, 24F);
            this.pvpStations.Location = new System.Drawing.Point(205, 4);
            this.pvpStations.Name = "pvpStations";
            this.pvpStations.Size = new System.Drawing.Size(624, 365);
            this.pvpStations.Text = "Stations";
            // 
            // gbStations
            // 
            this.gbStations.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbStations.Controls.Add(this.lvStations);
            this.gbStations.HeaderText = "Stations";
            this.gbStations.Location = new System.Drawing.Point(20, 14);
            this.gbStations.Name = "gbStations";
            this.gbStations.Size = new System.Drawing.Size(586, 337);
            this.gbStations.TabIndex = 1;
            this.gbStations.Text = "Stations";
            this.gbStations.ThemeName = "VisualStudio2012Dark";
            // 
            // lvStations
            // 
            this.lvStations.AllowEdit = false;
            this.lvStations.AllowRemove = false;
            listViewDetailColumn7.HeaderText = "Name";
            listViewDetailColumn8.HeaderText = "Link";
            listViewDetailColumn9.HeaderText = "Categories";
            this.lvStations.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn7,
            listViewDetailColumn8,
            listViewDetailColumn9});
            this.lvStations.ItemSpacing = -1;
            this.lvStations.Location = new System.Drawing.Point(27, 37);
            this.lvStations.Name = "lvStations";
            this.lvStations.Size = new System.Drawing.Size(531, 283);
            this.lvStations.TabIndex = 0;
            this.lvStations.ThemeName = "VisualStudio2012Dark";
            this.lvStations.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvStations.DoubleClick += new System.EventHandler(this.lvStations_DoubleClick);
            // 
            // pvpHome
            // 
            this.pvpHome.Controls.Add(this.gbSongs);
            this.pvpHome.Controls.Add(this.gbPlaylists);
            this.pvpHome.ItemSize = new System.Drawing.SizeF(52F, 24F);
            this.pvpHome.Location = new System.Drawing.Point(205, 4);
            this.pvpHome.Name = "pvpHome";
            this.pvpHome.Size = new System.Drawing.Size(624, 365);
            this.pvpHome.Text = "Music";
            // 
            // gbSongs
            // 
            this.gbSongs.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbSongs.Controls.Add(this.lvSongs);
            this.gbSongs.HeaderText = "Songs";
            this.gbSongs.Location = new System.Drawing.Point(286, 12);
            this.gbSongs.Name = "gbSongs";
            this.gbSongs.Size = new System.Drawing.Size(403, 337);
            this.gbSongs.TabIndex = 4;
            this.gbSongs.Text = "Songs";
            this.gbSongs.ThemeName = "VisualStudio2012Dark";
            // 
            // lvSongs
            // 
            this.lvSongs.AllowEdit = false;
            this.lvSongs.AllowRemove = false;
            listViewDetailColumn1.HeaderText = "Fullpath";
            listViewDetailColumn1.Visible = false;
            listViewDetailColumn2.HeaderText = "Name";
            listViewDetailColumn2.Width = 300F;
            this.lvSongs.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2});
            this.lvSongs.ItemSpacing = -1;
            this.lvSongs.Location = new System.Drawing.Point(18, 32);
            this.lvSongs.Name = "lvSongs";
            this.lvSongs.Size = new System.Drawing.Size(301, 283);
            this.lvSongs.TabIndex = 0;
            this.lvSongs.Text = "radListView2";
            this.lvSongs.ThemeName = "VisualStudio2012Dark";
            this.lvSongs.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvSongs.DoubleClick += new System.EventHandler(this.lvSongs_DoubleClick);
            // 
            // gbPlaylists
            // 
            this.gbPlaylists.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPlaylists.Controls.Add(this.lvPlaylists);
            this.gbPlaylists.HeaderText = "Playlists";
            this.gbPlaylists.Location = new System.Drawing.Point(15, 12);
            this.gbPlaylists.Name = "gbPlaylists";
            this.gbPlaylists.Size = new System.Drawing.Size(252, 337);
            this.gbPlaylists.TabIndex = 3;
            this.gbPlaylists.Text = "Playlists";
            this.gbPlaylists.ThemeName = "VisualStudio2012Dark";
            // 
            // lvPlaylists
            // 
            this.lvPlaylists.AllowEdit = false;
            this.lvPlaylists.AllowRemove = false;
            listViewDetailColumn3.HeaderText = "Name";
            listViewDetailColumn3.Width = 215F;
            this.lvPlaylists.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn3});
            this.lvPlaylists.ItemSpacing = -1;
            this.lvPlaylists.Location = new System.Drawing.Point(18, 32);
            this.lvPlaylists.Name = "lvPlaylists";
            this.lvPlaylists.Size = new System.Drawing.Size(216, 283);
            this.lvPlaylists.TabIndex = 0;
            this.lvPlaylists.Text = "radListView1";
            this.lvPlaylists.ThemeName = "VisualStudio2012Dark";
            this.lvPlaylists.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvPlaylists.DoubleClick += new System.EventHandler(this.lvPlaylists_DoubleClick);
            // 
            // pvMenu
            // 
            this.pvMenu.Controls.Add(this.pvpHome);
            this.pvMenu.Controls.Add(this.pvpStations);
            this.pvMenu.Controls.Add(this.pvpSettings);
            this.pvMenu.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            this.pvMenu.Location = new System.Drawing.Point(12, 12);
            this.pvMenu.Name = "pvMenu";
            this.pvMenu.SelectedPage = this.pvpHome;
            this.pvMenu.Size = new System.Drawing.Size(833, 373);
            this.pvMenu.TabIndex = 3;
            this.pvMenu.Text = "Home";
            this.pvMenu.ThemeName = "VisualStudio2012Dark";
            this.pvMenu.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            ((Telerik.WinControls.UI.RadPageViewBackstageElement)(this.pvMenu.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.Location = new System.Drawing.Point(174, 487);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(106, 24);
            this.btnPlayMode.TabIndex = 7;
            this.btnPlayMode.Text = "Repeat song : ON";
            this.btnPlayMode.ThemeName = "VisualStudio2012Dark";
            this.btnPlayMode.Click += new System.EventHandler(this.btnPlayMode_Click);
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(286, 487);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(87, 24);
            this.btnFullscreen.TabIndex = 8;
            this.btnFullscreen.Text = "Fullscreen";
            this.btnFullscreen.ThemeName = "VisualStudio2012Dark";
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Fenix Music";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(174, 407);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(679, 64);
            this.axWindowsMediaPlayer.TabIndex = 0;
            this.axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer_PlayStateChange);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 569);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.btnPlayMode);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.pvMenu);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHome";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Fenix Music 1.0 - Copyright © Ismael Heredia 2021";
            this.ThemeName = "VisualStudio2012Dark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.Resize += new System.EventHandler(this.FormHome_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            this.pvpSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbGeneratePlaylist)).EndInit();
            this.gbGeneratePlaylist.ResumeLayout(false);
            this.gbGeneratePlaylist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectoryToScan)).EndInit();
            this.pvpStations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbStations)).EndInit();
            this.gbStations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvStations)).EndInit();
            this.pvpHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbSongs)).EndInit();
            this.gbSongs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPlaylists)).EndInit();
            this.gbPlaylists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvPlaylists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMenu)).EndInit();
            this.pvMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFullscreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.PictureBox pbCover;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement lblStatus;
        private Telerik.WinControls.UI.RadPageViewPage pvpSettings;
        private Telerik.WinControls.UI.RadGroupBox gbGeneratePlaylist;
        private Telerik.WinControls.UI.RadLabel lblDirectory;
        private Telerik.WinControls.UI.RadTextBox txtDirectoryToScan;
        private Telerik.WinControls.UI.RadPageViewPage pvpStations;
        private Telerik.WinControls.UI.RadGroupBox gbStations;
        private Telerik.WinControls.UI.RadListView lvStations;
        private Telerik.WinControls.UI.RadPageViewPage pvpHome;
        private Telerik.WinControls.UI.RadGroupBox gbSongs;
        private Telerik.WinControls.UI.RadListView lvSongs;
        private Telerik.WinControls.UI.RadGroupBox gbPlaylists;
        private Telerik.WinControls.UI.RadListView lvPlaylists;
        private Telerik.WinControls.UI.RadPageView pvMenu;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.UI.RadButton btnPlayMode;
        private Telerik.WinControls.UI.RadButton btnFullscreen;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}