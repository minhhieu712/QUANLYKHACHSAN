using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TANG
    {
        Entities db;
        public TANG()
        {
            db = Entities.CreateEntities();
        }
        public tb_Tang getItem(string matang)
        {
            return db.tb_Tang.FirstOrDefault(x => x.IDTANG.ToString() == matang);
        }
        public List<tb_Tang>getAll()
        {
            return db.tb_Tang.ToList();
        }
        public void add(tb_Tang tang)
        {
            try
            {
                db.tb_Tang.Add(tang);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Tang tang)
        {
            tb_Tang _tang = db.tb_Tang.FirstOrDefault(x => x.IDTANG == tang.IDTANG);
            _tang.TENTANG = tang.TENTANG;
            
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
                var _matang = db.tb_Tang.Find(mt); // Tìm đối tượng cần xóa
                if (_matang != null)
                {
                    db.tb_Tang.Remove(_matang); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
