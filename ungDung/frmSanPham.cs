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
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        SANPHAM _SanPham;
        bool _them;
        string _masanpham;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _SanPham = new SANPHAM();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMaSP.Enabled = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _SanPham.getAll();
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
            txtTenSP.Enabled = t;
            txtDonGia.Enabled = t;
        }

        void _reset()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMaSP.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _SanPham.delete(_masanpham);
            }
            _reset();
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                int msp = int.Parse(txtMaSP.Text);
                float dg = float.Parse(txtDonGia.Text);
                tb_SanPham sanpham = new tb_SanPham();
                sanpham.IDSP = msp;
                sanpham.TENSP = txtTenSP.Text;
                sanpham.DONGIA = dg;
                _SanPham.add(sanpham);
            }
            else
            {
                tb_SanPham sanpham = _SanPham.getItem(_masanpham);
                float dg = float.Parse(txtDonGia.Text);
                sanpham.TENSP = txtTenSP.Text;
                sanpham.DONGIA = dg;
                _SanPham.update(sanpham);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMaSP.Enabled = false;
            _enabled(false);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = false;
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
                _masanpham = gvDanhSach.GetFocusedRowCellValue("IDSP").ToString();
                txtMaSP.Text = gvDanhSach.GetFocusedRowCellValue("IDSP").ToString();
                txtTenSP.Text = gvDanhSach.GetFocusedRowCellValue("TENSP").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
            }
        }

      
    }
}