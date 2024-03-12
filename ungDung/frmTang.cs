using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ungDung
{
    public partial class frmTang : DevExpress.XtraEditors.XtraForm
    {
        public frmTang()
        {
            InitializeComponent();
        }
        TANG _Tang;
        bool _them;
        string _matang;
        private void frmTang_Load(object sender, EventArgs e)
        {
            _Tang = new TANG();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMATANG.Enabled = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _Tang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void _enabled(bool t)
        {
            txtTang.Enabled = t;

        }

        void _reset()
        {
            txtMATANG.Text = "";
            txtTang.Text = "";
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMATANG.Enabled = true;
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMATANG.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Tang.delete(_matang);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                int mt = int.Parse(txtMATANG.Text);
                tb_Tang tang = new tb_Tang();
                tang.IDTANG = mt;
                tang.TENTANG = txtTang.Text;

                _Tang.add(tang);
            }
            else
            {
                tb_Tang tang = _Tang.getItem(_matang);
                tang.TENTANG = txtTang.Text;
                _Tang.update(tang);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMATANG.Enabled = false;
            _enabled(false);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMATANG.Enabled = false;
            _them = false;
            showHideControl(true);
            _enabled(false);
            _reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _matang = gvDanhSach.GetFocusedRowCellValue("IDTANG").ToString();
                txtMATANG.Text = gvDanhSach.GetFocusedRowCellValue("IDTANG").ToString();
                txtTang.Text = gvDanhSach.GetFocusedRowCellValue("TENTANG").ToString();
            }
        }

    }
}