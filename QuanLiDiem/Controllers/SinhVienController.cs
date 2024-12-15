using QuanLiDiem.Models;
using Microsoft.AspNetCore.Mvc;
using QuanLiDiem.Data;

namespace QuanLiDiem.Controllers
{
    public class SinhVienController : Controller
    {

        //private static List<SinhVien> sinhviens = new List<SinhVien>
        //{
        //new SinhVien { ID = 1, HoVaTen = "Nguyễn Văn A", SDT = "0123456789", CCCD = "36780725618", QueQuan = "Tây Ninh", NganhHoc = "Sư phạm Anh", DiemTBM1 = 8.2, DiemTBM2 = 8.7, DiemTBM3 = 8.7, XepLoai = "Giỏi" },
        //new SinhVien { ID = 2, HoVaTen = "Lê Thị B", SDT = "0254746872", CCCD = "40586730245", QueQuan = "Hải Phòng", NganhHoc = "Kinh tế", DiemTBM1 = 7.3, DiemTBM2 = 7.5, DiemTBM3 = 6.8, XepLoai = "Khá" },
        // Thêm các sinh viên khác tại đây
        //};

        private readonly ApplicationDbContext _context;
        public SinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sinhviens = _context.DanhSachDK.ToList();
            return View(sinhviens);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        /*
        // POST: SinhVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhvien);
        }
        */

        
        // POST: SinhVien/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sinhvien = _context.DanhSachDK.Find(id);
            if (sinhvien != null)
            {
                _context.DanhSachDK.Remove(sinhvien);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        
    }

}
