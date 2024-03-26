using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class THIETBI_PHONG
    {
        Entities db;
        public THIETBI_PHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_Phong_ThietBi getItem(string maphong)
        {
            return db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG.ToString() == maphong);
        }
        public List<tb_Phong_ThietBi> getAll()
        {
            return db.tb_Phong_ThietBi.ToList();
        }
        public void add(tb_Phong_ThietBi mathietbi)
        {
            try
            {
                db.tb_Phong_ThietBi.Add(mathietbi);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Phong_ThietBi mathietbi)
        {
            tb_Phong_ThietBi _mathietbi = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDTB == mathietbi.IDTB);
            _mathietbi.IDTB = mathietbi.IDTB;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(string maphong)
        {
            {
                int mp = int.Parse(maphong);
                var _maphong = db.tb_Phong_ThietBi.Find(mp); // Tìm đối tượng cần xóa
                if (_maphong != null)
                {
                    db.tb_Phong_ThietBi.Remove(_maphong); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
