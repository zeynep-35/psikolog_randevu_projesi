using Microsoft.AspNetCore.Mvc;
using psikolog_randevu_projesi.DTO;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Soyut;

namespace psikolog_randevu_projesi.Controllers
{
    public class AuthController : Controller
    {
        private const string ControllerName = "Appointment";
        private readonly IKullaniciRepository _kullaniciRepository;

        public AuthController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            Kullanici kullanici = _kullaniciRepository.GetByMail(loginDTO.e_posta);
            if (kullanici== null)
            return View();

            if(kullanici.sifre!= loginDTO.sifre)
                return View();

            if (loginDTO.e_posta == "admin@gmail.com")
                return RedirectToAction("Index", "Admin", new {id= kullanici.Id, adsoyad=kullanici.ad_soyad });
            else
                return RedirectToAction("Index", "Appointment", new { id = kullanici.Id,adsoyad= kullanici.ad_soyad});
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            Kullanici kullanici = new Kullanici(); 
            
            kullanici.kullaniici_adi= registerDTO.kullaniici_adi;
            kullanici.tc_kimlik_numarasi = registerDTO.tc_kimlik_numarasi;
            kullanici.ad_soyad= registerDTO.ad_soyad;   
            kullanici.tel_nu= registerDTO.tel_nu;   
            kullanici.e_posta= registerDTO.e_posta; 
            kullanici.sifre=registerDTO.sifre;

            _kullaniciRepository.Insert(kullanici);
           

            return RedirectToAction("Index", "Appointment", new { id = kullanici.Id });
        }
        public IActionResult SignOut()
        {
            ViewBag.kullaniciId = null;
            return RedirectToAction("Login");
        }
    }
}
