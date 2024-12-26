using Microsoft.AspNetCore.Mvc;
using QuanLiDiem.Models;
using QuanLiDiem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action GET để hiển thị form đăng ký
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // Action POST để xử lý đăng ký
    [HttpPost]
    public async Task<IActionResult> Register(RegistrationModel registration)
    {
        if (ModelState.IsValid)
        {
            _context.Add(registration);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đăng ký thành công, vui lòng đăng nhập.";

            return RedirectToAction("Login");
        }

        return View(registration);
    }

    // Action GET để hiển thị form đăng nhập
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Action POST để xử lý đăng nhập
    [HttpPost]
    public IActionResult Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            // Kiểm tra thông tin đăng nhập với bảng DanhSachSinhVien
            var user = _context.DanhSachSinhVien
                .FirstOrDefault(u => u.TenTaiKhoan == login.TenTaiKhoan && u.MatKhau == login.MatKhau);

            if (user != null)
            {
                // Đăng nhập thành công
                return RedirectToAction("Index"); // Chuyển hướng đến trang Index
            }
            else
            {
                // Thêm lỗi vào ModelState nếu đăng nhập không thành công
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        return View(login);
    }

    // Action để hiển thị trang Index
    public IActionResult Index()
    {
        return View();
    }

    // Action GET để hiển thị form đổi mật khẩu
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    // Action POST để xử lý đổi mật khẩu
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.DanhSachSinhVien
                .FirstOrDefault(u => u.TenTaiKhoan == model.TenTaiKhoan);

            if (user != null && user.MatKhau == model.MatKhauCu)
            {
                if (model.MatKhauMoi == model.XacNhanMatKhau)
                {
                    // Cập nhật mật khẩu trong cơ sở dữ liệu
                    user.MatKhau = model.MatKhauMoi;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Mật khẩu đã được thay đổi thành công.";

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu mới và mật khẩu xác nhận không khớp.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu cũ không đúng.");
            }
        }

        return View(model);
    }
}
