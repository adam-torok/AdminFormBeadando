using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Presenters;
using AdminForm.Views;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace AdminForm
{
    public partial class Form1 : MaterialForm, IUserList, ISongList
    {
        //Dropshadow
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private adatbazis context = new adatbazis();
        private UserListPresenter userpresenter;
        private SongListPresenter songpresenter;
        private DataGridViewComboBoxColumn userCol;
        private DataGridViewComboBoxColumn songCol;

        // Oldaltördelés
        private int pageCount;
        private int sortIndex;
        public Form1()
        {
       
            InitializeComponent();
         
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red400, Primary.Red400,
                Primary.Red400, Accent.Red700,
                TextShade.WHITE
            );

            userpresenter = new UserListPresenter(this);
            songpresenter = new SongListPresenter(this);
            userCol = new DataGridViewComboBoxColumn();
            songCol = new DataGridViewComboBoxColumn();
            Init();
        }
        public void Init()
        {
            pageNumber = 1;
            itemsPerPage = 10;
            sortBy = "Id";
            sortIndex = 0;
            ascending = true;
        }

        public BindingList<songs> songLista
        {
            get => (BindingList<songs>)dataGridView2.DataSource;
            set => dataGridView2.DataSource = value;
        }
        public BindingList<songs> bindingListSong 
        {
            get => (BindingList<songs>)dataGridView2.DataSource;
            set => dataGridView2.DataSource = value;
        }

        public BindingList<felhasznalo> userLista
        {
            get => (BindingList<felhasznalo>)dataGridView1.DataSource;
            set => dataGridView1.DataSource = value;
        }
        public BindingList<felhasznalo> bindingList
        {
            get => (BindingList<felhasznalo>)dataGridView1.DataSource;
            set => dataGridView1.DataSource = value;
        }

        public int pageNumber { get; set; }
        public int itemsPerPage { get; set; }
        public string search => keresestoolStripTextBox.Text;
        public string sortBy { get; set; }
        public bool ascending { get; set; }

        public int totalItems
        {
            set
            {
                pageCount = (value - 1) / itemsPerPage + 1;
                materialLabelCounter.Text = pageNumber.ToString() + "/" + pageCount.ToString();
            }
        }

        BindingList<songs> IDataGridList<songs>.bindingList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            userpresenter.LoadData();
            songpresenter.LoadData();     
            materialLabelUserCount.Text += Convert.ToString(userLista.Count());
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                tableLayoutPanel1.Show();
                userpresenter.LoadData();
            }
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
            {
                tableLayoutPanel1.Show();
                songpresenter.LoadData();
            }
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["Info"])
            {
                tableLayoutPanel1.Hide();
            }

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            songsBindingSource.EndEdit();
            songpresenter.Save();
            userpresenter.Save();    
        }

        private void materialRaisedButtondDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void newRecord()
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                using (var szerkForm = new AddUserForm())
                {
                    DialogResult dr = szerkForm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        userpresenter.Add(szerkForm.felhasznalo);
                        szerkForm.Close();
                    }
                }
            }
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
            {
                using (var szerkForm = new AddSongForm())
                {
                    DialogResult dr = szerkForm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        songpresenter.Add(szerkForm.songs);
                        szerkForm.Close();
                    }
                }
            }
        }

        private void EditDGRow(int index)
        {
            var jk = (felhasznalo)dataGridView1.Rows[index].DataBoundItem;

            if (jk != null)
            {
                using (var modForm = new AddUserForm())
                {
                    modForm.felhasznalo = jk;
                    DialogResult dr = modForm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        userpresenter.Modify(modForm.felhasznalo);
                        modForm.Close();
                    }
                }
            }
        }


        private void Delete()
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                while (dataGridView1.SelectedRows.Count > 0)
                {
                    userpresenter.Remove(dataGridView1.SelectedRows[0].Index);
                }
            }
            else
            {
                while (dataGridView2.SelectedRows.Count > 0)
                {
                    songpresenter.Remove(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void materialFlatButtonFirst_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                pageNumber = 1;
                userpresenter.LoadData();
            }
            else
            {
                pageNumber = 1;
                songpresenter.LoadData();
            }
          
        }

        private void materialFlatBack_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                if (pageNumber != 1)
                {
                    pageNumber--;
                    userpresenter.LoadData();
                }
            }
            else
            {
                if (pageNumber != 1)
                {
                    pageNumber--;
                    songpresenter.LoadData();
                }
            }       
        }

        private void materialFlatButtonForw_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                if (pageNumber != pageCount)
                {
                    pageNumber++;
                    userpresenter.LoadData();
                }
            }
            else
            {
                if (pageNumber != pageCount)
                {
                    pageNumber++;
                    songpresenter.LoadData();
                }
            }  
        }

        private void materialFlatButtonLast_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                pageNumber = pageCount;
                userpresenter.LoadData();
            }
            else
            {
                pageNumber = pageCount;
                songpresenter.LoadData();
            }
           
        }

        private void materialRaisedButtonNewUser_Click(object sender, EventArgs e)
        {
            newRecord();
        }

        private void materialRaisedButtonNewsletterOpener_Click(object sender, EventArgs e)
        {
            Newsletter lt = new Newsletter();
            lt.Show();
        }

        private void materialRaisedButtonnr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                var sorIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[sorIndex].Selected = true;
                EditDGRow(dataGridView1.SelectedRows[0].Index);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            userpresenter.LoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.ColumnIndex == 6)
            {
                MessageBox.Show("Kérem az egész szám után vesszővel válassza el a tört értéket.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(e.Exception.Message);
            }

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortIndex == e.ColumnIndex)
            {
                ascending = !ascending;
            }
            switch (e.ColumnIndex)
            {
                case 1:
                    sortBy = "id";
                    break;
                case 2:
                    sortBy = "felhnev";
                    break;
                case 3:
                    sortBy = "password";
                    break;
                case 4:
                    sortBy = "email";
                    break;
                case 5:
                    sortBy = "profpic";
                    break;
                case 6:
                    sortBy = "time";
                    break;
                case 7:
                    sortBy = "bio";
                    break;
                default:
                    sortBy = "Id";
                    break;
            }

            sortIndex = e.ColumnIndex;

            userpresenter.LoadData();
        }

        private void materialRaisedButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
       
        }
    }
}
