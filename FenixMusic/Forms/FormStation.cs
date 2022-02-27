// Fenix Music 1.3
// Copyright © Ismael Heredia 2022

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace FenixMusic
{
    public partial class FormStation : Telerik.WinControls.UI.RadForm
    {
        public string program_title;
        public FormHome formHome;
        public int id_station;

        public FormStation(FormHome formHome_here, int id_station_here)
        {
            InitializeComponent();
            program_title = System.Configuration.ConfigurationManager.AppSettings["program_title"];
            formHome = formHome_here;
            id_station = id_station_here;
            RadMessageBox.SetThemeName("VisualStudio2012Dark");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string link = txtLink.Text;
            string categories = txtCategories.Text;

            if (name != "" && link != "" && categories != "")
            {
                if (id_station == 0)
                {
                    DataStation dataStation = new DataStation();
                    Station station = new Station();
                    station.Name = name;
                    station.Link = link;
                    station.Categories = categories;
                    if (dataStation.Add(station) == true)
                    {
                        RadMessageBox.Show("Station created", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        formHome.loadStations();
                        FormStation.ActiveForm.Close();
                    }
                    else
                    {
                        RadMessageBox.Show("Error making station", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    DataStation dataStation = new DataStation();
                    Station station = new Station();
                    station.Id = id_station;
                    station.Name = name;
                    station.Link = link;
                    station.Categories = categories;
                    if (dataStation.Update(station) == true)
                    {
                        RadMessageBox.Show("Station updated", program_title, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);
                        formHome.loadStations();
                        FormStation.ActiveForm.Close();
                    }
                    else
                    {
                        RadMessageBox.Show("Error updating station", program_title, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                RadMessageBox.Show("Complete form", program_title, MessageBoxButtons.OK, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormStation_Load(object sender, EventArgs e)
        {
            if (id_station > 0)
            {
                DataStation dataStation = new DataStation();
                Station stationData = dataStation.Get(id_station);
                string name = stationData.Name;
                string link = stationData.Link;
                string categories = stationData.Categories;
                txtName.Text = name;
                txtLink.Text = link;
                txtCategories.Text = categories;
            }
        }
    }
}
