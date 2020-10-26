﻿using BL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomateEverything
{
    public partial class MainWindow : Form
    {
        private PodcastController podcastController;

        public MainWindow()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            fillTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void fillTable()
        {
            //
            var podcastList = podcastController.GetAllPodcasts();

            //foreach (var p in podcastList)
            //{
            //    dgPodcastFeed.Rows.Add(p.Name, p.Interval, p.Category);
            //}

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string name = txtName.Text;
            string category = cbCategory.SelectedItem.ToString();
            int interval = Convert.ToInt32(cbUpdate.SelectedItem);

            podcastController.AddNewPodcast(url, name, category, interval);
        }
    }
}