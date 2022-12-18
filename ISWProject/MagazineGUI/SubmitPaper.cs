﻿using Magazine.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazineGUI
{
    public partial class SubmitPaper : Form
    {
        private IMagazineISWService service;
        private Boolean areaOk = false, titleOk = false;
        public SubmitPaper(IMagazineISWService service)
        {
            InitializeComponent();
            this.service = service;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void AcceptClick(object sender, EventArgs e)
        {
            try
            {
                int areaId = service.GetIdByAreaName(areaBox.Text);
                service.SubmitPaper(areaId, titleBox.Text, DateTime.Now);
                this.Close();
            } catch (Exception ex) {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnableAcceptButton ()
        {
            if (areaOk && titleOk) acceptButton.Enabled = true;
            else acceptButton.Enabled = false;
        }

        private void AreaTextChanged(object sender, EventArgs e)
        {
            if (areaBox.Text.Length == 0) areaOk = false;
            else areaOk = true;
            EnableAcceptButton();
        }

        private void TitleTextChanged(object sender, EventArgs e)
        {
            if (titleBox.Text.Length == 0) titleOk = false;
            else titleOk = true;
            EnableAcceptButton();
        }
    }
}
