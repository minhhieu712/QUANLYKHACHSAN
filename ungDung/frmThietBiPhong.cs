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
    public partial class frmThietBiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmThietBiPhong()
        {
            InitializeComponent();
        }
        THIETBI_PHONG _thietbiphong;
        bool _them;
        string _maphong;

        private void frmThietBiPhong_Load(object sender, EventArgs e)
        {
            _thietbiphong = new THIETBI_PHONG();
            loadData();
            showHideControl(true);
            _enabled(false);
            txtMaPhong.Enabled = false;
            txtMaTB.Enabled=false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _thietbiphong.getAll();
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
            txtSoLuong.Enabled = t;
         
        }

        void _reset()
        {
            txtMaPhong.Text = "";
            txtMaTB.Text = "";
            txtSoLuong.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhong.Enabled = true;
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
            txtMaPhong.Enabled = false;
            txtMaTB.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _thietbiphong.delete(_maphong);
            }
            _reset();
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                int mp = int.Parse(txtMaPhong.Text);
                int mtb = int.Parse(txtMaTB.Text);
                int sl = int.Parse(txtSoLuong.Text);
                tb_Phong_ThietBi thietbiphong = new tb_Phong_ThietBi();
                thietbiphong.IDPHONG = mp;
                thietbiphong.IDTB = mtb;
                thietbiphong.SOLUONG = sl;
                _thietbiphong.add(thietbiphong);
            }
            else
            {
                tb_Phong_ThietBi thietbiphong = _thietbiphong.getItem(_maphong);
                int sl = int.Parse(txtSoLuong.Text);
                thietbiphong.SOLUONG = sl;

                _thietbiphong.update(thietbiphong);
            }
            _them = false;
            loadData();
            showHideControl(true);
            txtMaPhong.Enabled = false;
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
                txtMaTB.Text = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtSoLuong.Text = gvDanhSach.GetFocusedRowCellValue("SOLUONG").ToString();
            }
        }
    }
}