using Microsoft.AspNetCore.Mvc;
using psikolog_randevu_projesi.DTO;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Somut;
using psikolog_randevu_projesi.VeriErisim.Soyut;

namespace psikolog_randevu_projesi.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRandevuKayitRepository _randevuKayitRepository;
        private readonly IHizmetRepository _hizmetRepository;
        private readonly IKullaniciRepository _kullaniciRepository;
        public int authId;

        public AppointmentController(IRandevuKayitRepository randevuRepository, IKullaniciRepository kullaniciRepository, IHizmetRepository hizmetRepository)
        {
            _randevuKayitRepository = randevuRepository;
            _kullaniciRepository = kullaniciRepository;
            _hizmetRepository = hizmetRepository;
        }
        [HttpGet]
        public IActionResult Index(int kullaniciId, string adsoyad)
        {
            ViewBag.kullaniciId = kullaniciId;
            ViewBag.adsoyad = adsoyad;
            authId = kullaniciId;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AppointmentCreateDTO appointmentCreateDTO,int id)
        {
            RandevuKayıt randevuKayıt = new RandevuKayıt();
            var user = _kullaniciRepository.GetByID(id);
            var hizmet = _hizmetRepository.GetByID(appointmentCreateDTO.HizmetId);

            if (user !=null) // Kullanıcı Bulunursa
            {
                randevuKayıt.Kullanici = user;
                randevuKayıt.KullaniciId = user.Id;
                randevuKayıt.Hizmet = hizmet;
                randevuKayıt.HizmetId = hizmet.Id;
                randevuKayıt.psikolog_adi = appointmentCreateDTO.psikolog_adi;
                randevuKayıt.randevu_bitis_tarihi = appointmentCreateDTO.randevu_bitis_tarihi;
                randevuKayıt.randevu_baslangic_tarihi = appointmentCreateDTO.randevu_baslangic_tarihi;
                randevuKayıt.hasta_bilgi = appointmentCreateDTO.hasta_bilgi;

                _randevuKayitRepository.Insert(randevuKayıt);

                return View();
            }
            else
            {
                return NotFound(); // Kullanıcı Bulunamazsa
            }
           
        }
    }
}
