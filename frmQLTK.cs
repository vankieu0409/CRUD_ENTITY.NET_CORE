using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CRUD_ENTITY.NET_CORE.Models;

namespace CRUD_ENTITY.NET_CORE
{
    public partial class QLTK : Form
    {
        private Services SV;

        public QLTK()
        {
            SV = new Services();
            InitializeComponent();
            LoadData(); 
            foreach (var x in SV.GetRoles())
            {
                cbx_roleld.Items.Add(x.Name);
            }
            cbx_roleld.SelectedIndex = 0;
        }

        private void LoadData()
        {

            // loadData vào Griwview
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Tài Khoản";
            dataGridView1.Columns[1].Name = "Mật Khẩu";
            dataGridView1.Columns[2].Name = "Quyền";
            dataGridView1.Rows.Clear();
            foreach (var x in SV.GetListService())
            {
                dataGridView1.Rows.Add(x.Acc, x.Pass,
                    SV.GetRoles().Where(c => c.Id == x.Roleld).Select(c => c.Name).FirstOrDefault());
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Id = Guid.NewGuid();
            acc.Acc = txt_Acc.Text;
            acc.Pass = txt_Pass.Text;
            acc.Roleld = SV.GetRoles().Where(c => c.Name == cbx_roleld.Text).Select(c => c.Id).FirstOrDefault();
            MessageBox.Show(SV.AddnewACC(acc), " Thông báo của UNBD Xã Tuân Chính");
            SV.getListACCFromDB();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Acc.Enabled = false;
            int rowIndex = e.RowIndex;
            if (rowIndex == SV.GetListService().Count || rowIndex == -1) return;
            txt_Acc.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Pass.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            cbx_roleld.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            var id = SV.GetListService().Where(c => c.Acc == txt_Acc.Text).Select(c => c.Id).FirstOrDefault();
            MessageBox.Show(SV.DeleteACC(id), " Thông báo Của UBND xã Thuân Chính");
            SV.getListACCFromDB();
            SV.GetListService();
            LoadData();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Id = SV.GetListService().Where(c => c.Acc == txt_Acc.Text).Select(c => c.Id).FirstOrDefault();
            acc.Acc = txt_Acc.Text;
            acc.Pass = txt_Pass.Text;
            acc.RoleldNavigation = SV.GetRoles().FirstOrDefault(c => c.Name == cbx_roleld.Text);
            MessageBox.Show(SV.UpdateAcc(acc), " Thông báo của UNBD Xã Tuân Chính");
            SV.getListACCFromDB();
            LoadData();
        }
    }
}
