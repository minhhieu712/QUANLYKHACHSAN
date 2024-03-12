using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SANPHAM
    {
        Entities db;
        public SANPHAM()
        {
            db = Entities.CreateEntities();
        }
        public tb_SanPham getItem(string masanpham)
        {
            return db.tb_SanPham.FirstOrDefault(x => x.IDSP.ToString() == masanpham);
        }
        public List<tb_SanPham> getAll()
        {
            return db.tb_SanPham.ToList();
        }
        public void add(tb_SanPham sanpham)
        {
            try
            {
                db.tb_SanPham.Add(sanpham);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_SanPham sanpham)
        {
            tb_SanPham _sanpham = db.tb_SanPham.FirstOrDefault(x => x.IDSP == sanpham.IDSP);
            _sanpham.TENSP = sanpham.TENSP;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(string masanpham)
        {
            {
                int msp = int.Parse(masanpham);
                var _masanpham = db.tb_SanPham.Find(msp); // Tìm đối tượng cần xóa
                if (_masanpham != null)
                {
                    db.tb_SanPham.Remove(_masanpham); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
