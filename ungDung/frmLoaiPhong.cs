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
    public partial class frmLoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        LOAIPHONG _LoaiPhong;
        bool _them;
        string _maloaiphong;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            _LoaiPhong = new LOAIPHONG();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMA.Enabled = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _LoaiPhong.getAll();
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
            txtTen.Enabled = t;
            txtDonGia.Enabled = t; 
            txtSoGiuong.Enabled = t;
            txtSoNguoi.Enabled = t; 
        }

        void _reset()
        {
            txtMA.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            txtSoGiuong.Text = "";
            txtSoNguoi.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMA.Enabled = true;
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMA.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _LoaiPhong.delete(_maloaiphong);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (_them)
            {
                int mt = int.Parse(txtMA.Text);
                int sn = int.Parse(txtSoNguoi.Text);
                int sg = int.Parse(txtSoGiuong.Text);
                tb_LoaiPhong loaiphong = new tb_LoaiPhong();
                loaiphong.IDLOAIPHONG = mt;
                loaiphong.TENLOAIPHONG = txtTen.Text;
                loaiphong.DONGIA=txtDonGia.Text;
                loaiphong.SONGUOI = sn;
                loaiphong.SOGIUONG = sg;
                _LoaiPhong.add(loaiphong);
            }
            else
            {
                int sn = int.Parse(txtSoNguoi.Text);
                int sg = int.Parse(txtSoGiuong.Text);
                tb_LoaiPhong loaiphong = _LoaiPhong.getItem(_maloaiphong);
               
                loaiphong.TENLOAIPHONG = txtTen.Text;
                loaiphong.DONGIA = txtDonGia.Text;
                loaiphong.SONGUOI = sn;
                loaiphong.SOGIUONG = sg;
                _LoaiPhong.update(loaiphong);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMA.Enabled = false;
            _enabled(false);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMA.Enabled = false;
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
                _maloaiphong = gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG").ToString();
                txtMA.Text = gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIPHONG").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                txtSoNguoi.Text = gvDanhSach.GetFocusedRowCellValue("SONGUOI").ToString();
                txtSoGiuong.Text = gvDanhSach.GetFocusedRowCellValue("SOGIUONG").ToString();
            }
        }
    }
}