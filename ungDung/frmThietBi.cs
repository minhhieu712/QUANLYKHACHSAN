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
    public partial class frmThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmThietBi()
        {
            InitializeComponent();
        }
        THIETBI _ThietBi;
        bool _them;
        string _mathietbi;
        private void frmThietBi_Load(object sender, EventArgs e)
        {
            _ThietBi = new THIETBI();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMaTB.Enabled = false;

        }
        void loadData()
        {
            gcDanhSach.DataSource = _ThietBi.getAll();
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
            txtTenTB.Enabled = t;
            txtDonGia.Enabled = t;
        }

        void _reset()
        {
            txtMaTB.Text = "";
            txtTenTB.Text = "";
            txtDonGia.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaTB.Enabled = true;
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMaTB.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ThietBi.delete(_mathietbi);
            }
            _reset();
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                int msp = int.Parse(txtMaTB.Text);
                float dg = float.Parse(txtDonGia.Text);
                tb_ThietBi thietbi = new tb_ThietBi();
                thietbi.IDTB = msp;
                thietbi.TENTB = txtTenTB.Text;
                thietbi.DONGIA = dg;
                _ThietBi.add(thietbi);
            }
            else
            {
                tb_ThietBi sanpham = _ThietBi.getItem(_mathietbi);
                float dg = float.Parse(txtDonGia.Text);
                sanpham.TENTB = txtTenTB.Text;
                sanpham.DONGIA = dg;
                _ThietBi.update(sanpham);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMaTB.Enabled = false;
            _enabled(false);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaTB.Enabled = false;
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
                _mathietbi = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtMaTB.Text = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtTenTB.Text = gvDanhSach.GetFocusedRowCellValue("TENTB").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
            }
        }
    }
}