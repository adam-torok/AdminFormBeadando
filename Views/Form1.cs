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
//MATERIAL VIEW
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
//PDF EXPORT
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;

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
        private SongPresenter sp;
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
            itemsPerPage = 15;
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
            materialLabelItemCounter.Text = Convert.ToString(context.felhasznalo.Count());
            songsBindingSource.DataSource = context.songs.ToList();
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userpresenter.LoadData();
            songpresenter.LoadData();
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                ShowElements();
                materialLabelCountName.Text = "Felhasználók száma:";
                materialLabelItemCounter.Text = Convert.ToString(context.felhasznalo.Count());
                materialRaisedButtonNewUser.Show();
                materialRaisedButtonNewUser.Enabled = true;
                tableLayoutPanel1.Show();
                userpresenter.LoadData();
            }
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
            {
                ShowElements();
                materialLabelCountName.Text = "Zeneszámok száma:";
                materialLabelItemCounter.Text = Convert.ToString(context.songs.Count());
                materialRaisedButtonNewUser.Enabled = false;
                materialRaisedButtonNewUser.Hide();
                tableLayoutPanel1.Show();
                songpresenter.LoadData();
            }
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["Info"])
            {
                materialTabControl1.TabPages["Info"].AutoScroll = true;
                HideElements();
            }
        }
        private void ShowElements()
        {
            tableLayoutPanel1.Show();
            materialDivider2.Show();
            materialProgressBar1.Show();
            materialLabelCounter.Show();
            materialLabelItemCounter.Show();
            materialLabelCountName.Show();
            materialFlatBack.Show();
            materialFlatButtonFirst.Show();
            materialRaisedButton1.Show();
            materialRaisedButton2.Show();
            materialRaisedButton3.Show();
            materialRaisedButtonnr.Show();
            materialRaisedButtondDelete.Show();
            materialRaisedButtonNewsletterOpener.Show();
            toolStrip1.Show();
        }
        private void HideElements()
        {
            tableLayoutPanel1.Hide();
            materialDivider2.Hide();
            materialProgressBar1.Hide();
            materialRaisedButtonNewUser.Hide();
            materialLabelCounter.Hide();
            materialLabelItemCounter.Hide();
            materialLabelCountName.Hide();
            materialFlatBack.Hide();
            materialFlatButtonFirst.Hide();
            materialRaisedButton1.Hide();
            materialRaisedButton2.Hide();
            materialRaisedButton3.Hide();
            materialRaisedButtonnr.Hide();
            materialRaisedButtondDelete.Hide();
            materialRaisedButtonNewsletterOpener.Hide();
            toolStrip1.Hide();
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
        }
        private void EditDGRow(int index)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
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

            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
            {
                var sk = (songs)dataGridView2.Rows[index].DataBoundItem;
                if (sk != null)
                {
                    using (var szerkForm = new AddSongForm())
                    {
                        szerkForm.songs = sk;
                        DialogResult dr = szerkForm.ShowDialog(this);
                        if (dr == DialogResult.OK)
                        {
                            songpresenter.Modify(szerkForm.songs);
                            szerkForm.Close();
                        }
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
                if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
                {
                    while (dataGridView2.SelectedRows.Count > 0)
                    {
                        songpresenter.Remove(dataGridView2.SelectedRows[0].Index);
                    }
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
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                if (dataGridView1.SelectedRows != null)
                {
                    var sorIndex = dataGridView1.SelectedCells[0].RowIndex;
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[sorIndex].Selected = true;
                    EditDGRow(dataGridView1.SelectedRows[0].Index);
                }
            }
            else
            {
                if (dataGridView2.SelectedRows != null)
                {
                    var sorIndex = dataGridView2.SelectedCells[0].RowIndex;
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[sorIndex].Selected = true;
                    EditDGRow(dataGridView2.SelectedRows[0].Index);
                }
            }        
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                userpresenter.LoadData();
            }
            else
            {
                songpresenter.LoadData();
            }
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
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
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
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
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
                        sortBy = "artist";
                        break;
                    case 3:
                        sortBy = "name";
                        break;
                    case 4:
                        sortBy = "genre";
                        break;
                    case 5:
                        sortBy = "filename";
                        break;
                    case 6:
                        sortBy = "covername";
                        break;
                    case 7:
                        sortBy = "uploadedby";
                        break;
                    default:
                        sortBy = "time";
                        break;
                }
                sortIndex = e.ColumnIndex;
                songpresenter.LoadData();
            }
        }
        private void materialRaisedButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            makePdf();
        }
        private void makePdf()
        {
            if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageUsers"])
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 35);
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Fájl neve...";
                dialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {ileName);
                }
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(dialog.FileName+".pdf", FileMode.Create));
                doc.Open();
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("mymusiclogo.png");
                    MessageBox.Show(dialog.F
                PNG.ScalePercent(50f);
                doc.Add(PNG);
                Paragraph para = new Paragraph("A myMusic felhasználói részletesen");
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(table);
                doc.Add(para);
                doc.Close();
            }
            else
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 35);
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Fájl neve...";
                dialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(dialog.FileName);
                }
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(dialog.FileName + ".pdf", FileMode.Create));
                doc.Open();
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("mymusiclogo.png");
                PNG.ScalePercent(50f);
                doc.Add(PNG);
                Paragraph para = new Paragraph("A myMusic zenéi részletesen");
                PdfPTable table = new PdfPTable(dataGridView2.Columns.Count);
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dataGridView2.Columns[i].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    for (int k = 0; k < dataGridView2.Columns.Count; k++)
                    {
                        if (dataGridView2[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView2[k, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(table);
                doc.Add(para);
                doc.Close();
            }
        }
        struct DataParameter
        {
            public List<songs> csvsonglist;
            
            public List<felhasznalo> csvuserlist;
            public string FileName { get; set; }
        }
        DataParameter _inputParameter;
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;
                using (SaveFileDialog sdf = new SaveFileDialog()
                {
                    Filter = "CSV|*.csv", ValidateNames = true
                })
                {
                    if (sdf.ShowDialog() == DialogResult.OK)
                {
                    if (materialTabControl1.SelectedTab == materialTabControl1.TabPages["tabPageSongs"])
                    {
                        _inputParameter.csvsonglist = songsBindingSource.DataSource as List<songs>;
                        _inputParameter.FileName = sdf.FileName;
                        materialProgressBar1.Minimum = 0;
                        materialProgressBar1.Value = 0;
                        backgroundWorker.RunWorkerAsync(_inputParameter);
                    }
                    else
                    {
                        _inputParameter.csvuserlist = felhasznaloBindingSource.DataSource as List<felhasznalo>;
                        _inputParameter.FileName = sdf.FileName;
                        materialProgressBar1.Minimum = 0;
                        materialProgressBar1.Value = 0;
                        backgroundWorkerIOUSER.RunWorkerAsync(_inputParameter);
                    }                   
                }
                }
            }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
                List<songs> list = ((DataParameter)e.Argument).csvsonglist;
                string filename = ((DataParameter)e.Argument).FileName;
                int index = 1;
                int process = list.Count;
                using (StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Create), Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Azonosító;Zenész;Zene neve;Műfaj;Fájlnév;Borítófájl;Feltöltő;Feltöltés ideje;Engedélyezve");
                    foreach (songs item in list)
                    {
                        if (!backgroundWorker.CancellationPending)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / process);
                            sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", item.id, item.artist, item.name, item.genre, item.filename, item.covername, item.uploadedby, item.time, item.approved));
                        }
                    }
                    sw.WriteLine(sb.ToString());
                }
            
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            materialProgressBar1.Value = e.ProgressPercentage;
            materialProgressBar1.Update();
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(1000);
        }
        private void backgroundWorkerIOUSER_DoWork(object sender, DoWorkEventArgs e)
        {
            List<felhasznalo> list = context.felhasznalo.ToList();
            string filename = ((DataParameter)e.Argument).FileName;
            int index = 1;
            int process = list.Count;
            using (StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Create), Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Azonosító;Felhasználónév;Jelszó;Email;Profilkép;Regisztráció dátuma;Leírás");
                    foreach (felhasznalo item in list)
                    {
                        if (!backgroundWorkerIOUSER.CancellationPending)
                        {
                            sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", item.id, item.felhnev, item.jelszo, item.email, item.profile_image, item.time, item.bio));
                        }
                    }
                    sw.WriteLine(sb.ToString());
                }
            }       
        private void backgroundWorkerIOUSER_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            materialProgressBar1.Value = e.ProgressPercentage;
            materialProgressBar1.Update();
        }
        private void backgroundWorkerIOUSER_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(1000);
        }
  
    }
}
