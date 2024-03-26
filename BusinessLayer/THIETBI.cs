using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class THIETBI
    {
        Entities db;
        public THIETBI()
        {
            db = Entities.CreateEntities();
        }
        public tb_ThietBi getItem(string masanpham)
        {
            return db.tb_ThietBi.FirstOrDefault(x => x.IDTB.ToString() == masanpham);
        }
        public List<tb_ThietBi> getAll()
        {
            return db.tb_ThietBi.ToList();
        }
        public void add(tb_ThietBi thietbi)
        {
            try
            {
                db.tb_ThietBi.Add(thietbi);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_ThietBi thietbi)
        {
            tb_ThietBi _thietbi = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == thietbi.IDTB);
            _thietbi.TENTB = thietbi.TENTB;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(string mathietbi)
        {
            {
                int mtb = int.Parse(mathietbi);
                var _mathietbi = db.tb_ThietBi.Find(mtb); // Tìm đối tượng cần xóa
                if (_mathietbi != null)
                {
                    db.tb_ThietBi.Remove(_mathietbi); // Xóa đối tượng
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
    }
}
