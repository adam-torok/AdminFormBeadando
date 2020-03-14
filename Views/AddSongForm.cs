using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Presenters;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminForm.Views
{
        public partial class AddSongForm : MaterialForm, ISong
        {
            private int id;
            private SongPresenter songpresenter;
            public AddSongForm()
            {
                InitializeComponent();
                songpresenter = new SongPresenter(this);
            }

            public songs songs
        {
                get
                {
                    var artist = materialSingleLineTextFieldArtistName.Text;
                    var name = materialSingleLineTextFieldSongName.Text;
                    var gennre = materialSingleLineTextFieldSongGenre.Text;
                    var filename = materialSingleLineTextFieldSongFileName.Text;
                    var covername = materialSingleLineTextFieldSongAlbumName.Text;
                    var time = dateTimePickerSong.Value;
                    var uploadedby = materialSingleLineTextFieldSongUploader.Text;
                    bool approved = checkBoxApproved.Checked;
                var asd = new songs(id, artist, name, gennre, filename, covername, uploadedby, time, approved);
                    if (id > 0)
                    {
                        asd.id = id;
                    }
                    return asd;
                }
                set
                {
                    id = value.id;
                    materialSingleLineTextFieldArtistName.Text = value.artist;
                    materialSingleLineTextFieldSongName.Text = value.name;
                    materialSingleLineTextFieldSongGenre.Text = value.genre;
                    materialSingleLineTextFieldSongFileName.Text = value.filename;
                    materialSingleLineTextFieldSongAlbumName.Text = value.covername;
                    dateTimePickerSong.Value = value.time > new DateTime(0001, 01, 01, 0, 00, 00) ?
                    value.time : new DateTime(1900, 1, 1);
                    materialSingleLineTextFieldSongUploader.Text = value.uploadedby;
                    checkBoxApproved.Checked = value.approved;
                }
            }

        public BindingList<songs> songlist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string errorMsg
        {
            get => errorProvider1.GetError(materialSingleLineTextFieldArtistName);
            set => errorProvider1.SetError(materialSingleLineTextFieldArtistName, value);
        }

        private void AddSongForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'felhasznaloDataSet1.songs' table. You can move, or remove it, as needed.
            this.songsTableAdapter.Fill(this.felhasznaloDataSet1.songs);

        }

        private void materialFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButtonSaveSong_Click(object sender, EventArgs e)
        {
            songpresenter.Save(this.songs);
            if (string.IsNullOrEmpty(errorMsg))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

