using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PHONG
    {
        Entities db;
        public PHONG() 
        {
            db = Entities.CreateEntities();    
        }
        public tb_Phong getItem(string maphong)
        {
            return db.tb_Phong.FirstOrDefault(x => x.IDPHONG.ToString() == maphong);
        }
        public List<tb_Phong> getAll()
        {
            return db.tb_Phong.ToList();
        }
        public List<tb_Phong> getByTang(int idTang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idTang).ToList();
        }
        public void add(tb_Phong phong)
        {
            try
            {
                db.tb_Phong.Add(phong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Phong phong)
        {
            tb_Phong _phong = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == phong.IDPHONG);
            _phong.TENPHONG = phong.TENPHONG;

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
                var _maphong = db.tb_Phong.Find(mp); // Tìm đối tượng cần xóa
                if (_maphong != null)
                {
                    db.tb_Phong.Remove(_maphong); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
