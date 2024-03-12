using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LOAIPHONG
    {
        Entities db;
        public LOAIPHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_LoaiPhong getItem(string maloaiphong)
        {
            return db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG.ToString() == maloaiphong);
        }
        public List<tb_LoaiPhong> getAll()
        {
            return db.tb_LoaiPhong.ToList();
        }
        public void add(tb_LoaiPhong loaiphong)
        {
            try
            {
                db.tb_LoaiPhong.Add(loaiphong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_LoaiPhong loaiphong)
        {
            tb_LoaiPhong _loaiphong = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == loaiphong.IDLOAIPHONG);
            _loaiphong.TENLOAIPHONG = loaiphong.TENLOAIPHONG;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(string matang)
        {
            {
                int mt = int.Parse(matang);
                var _matang = db.tb_LoaiPhong.Find(mt); // Tìm đối tượng cần xóa
                if (_matang != null)
                {
                    db.tb_LoaiPhong.Remove(_matang); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
