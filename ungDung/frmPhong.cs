using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ungDung
{
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        PHONG _Phong;
        bool _them;
        string _maphong;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            _Phong = new PHONG();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMaPhong.Enabled = false;
            txtMaTang.Enabled = false;
            txtMaLoaiPhong.Enabled = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _Phong.getAll();
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
            txtTenPhong.Enabled = t;
            chkTrangThai.Enabled = t;
        }

        void _reset()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtMaTang.Text = "";
            txtMaLoaiPhong.Text = "";
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhong.Enabled = true;
            txtMaTang.Enabled = true;
            txtMaLoaiPhong.Enabled = true;
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMaPhong.Enabled = false;
            txtMaTang.Enabled = false;
            txtMaLoaiPhong.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Phong.delete(_maphong);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (_them)
            {
                int mp = int.Parse(txtMaPhong.Text);
                int mlp = int.Parse(txtMaLoaiPhong.Text);
                int mt = int.Parse(txtMaTang.Text);
                tb_Phong phong = new tb_Phong();
                phong.IDPHONG = mp;
                phong.TENPHONG = txtTenPhong.Text;
                phong.IDLOAIPHONG = mlp;
                phong.IDTANG = mt;
                phong.TRANGTHAI = chkTrangThai.Checked;
                _Phong.add(phong);
            }
            else
            {
                int mlp = int.Parse(txtMaLoaiPhong.Text);
                int mt = int.Parse(txtMaTang.Text);
                tb_Phong phong = _Phong.getItem(_maphong);

                phong.TENPHONG = txtTenPhong.Text;
                phong.IDLOAIPHONG = mlp;
                phong.IDTANG = mt;
                phong.TRANGTHAI = chkTrangThai.Checked;
                _Phong.update(phong);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMaPhong.Enabled = false;
            txtMaTang.Enabled = false;
            txtMaLoaiPhong.Enabled = false;
            _enabled(false);
            _reset();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaPhong.Enabled = false;
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
                _maphong = gvDanhSach.GetFocusedRowCellValue("IDPHONG").ToString();
                txtMaPhong.Text = gvDanhSach.GetFocusedRowCellValue("IDPHONG").ToString();
                txtTenPhong.Text = gvDanhSach.GetFocusedRowCellValue("TENPHONG").ToString();
                txtMaTang.Text = gvDanhSach.GetFocusedRowCellValue("IDTANG").ToString();
                txtMaLoaiPhong.Text = gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG").ToString();
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TRANGTHAI").ToString());
            }
        }
    }
}