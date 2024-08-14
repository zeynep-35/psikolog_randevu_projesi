using Microsoft.AspNetCore.Mvc;
using psikolog_randevu_projesi.DTO;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Soyut;
using System.Linq;

namespace psikolog_randevu_projesi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRandevuKayitRepository _randevuKayitRepository;
        private readonly IKullaniciRepository _kullaniciRepository;
        private readonly IHizmetRepository _hizmetRepository;
        public AdminController(IRandevuKayitRepository randevuKayitRepository, IKullaniciRepository kullaniciRepository, IHizmetRepository hizmetRepository)
        {
            _randevuKayitRepository = randevuKayitRepository;
            _kullaniciRepository = kullaniciRepository;
            _hizmetRepository = hizmetRepository;
        }

        public IActionResult Index(int kullaniciId, string adsoyad)
        {
            ViewBag.kullaniciId = kullaniciId;
            ViewBag.adsoyad = adsoyad;

            // Randevu kayıtlarını ve hizmetleri al
            List<RandevuKayıt> values = _randevuKayitRepository.GetList();
            List<hizmet> services = _hizmetRepository.GetList();

            // Randevu kayıtlarındaki hizmetleri güncelle
            foreach (var randevu in values)
            {
                randevu.Hizmet = services.FirstOrDefault(s => s.Id == randevu.HizmetId);
            }

            return View(values);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
           var randevuKayıt= _randevuKayitRepository.GetByID(id);


            AppointmentUpdateDTO dto= new AppointmentUpdateDTO();

            dto.Id = randevuKayıt.Id;
            dto.randevu_bitis_tarihi= randevuKayıt.randevu_baslangic_tarihi;
            dto.randevu_baslangic_tarihi = randevuKayıt.randevu_baslangic_tarihi;
            dto.hasta_bilgi= randevuKayıt .hasta_bilgi;
            dto.HizmetId= randevuKayıt.HizmetId;
            dto.KullaniciId=randevuKayıt.HizmetId ;
            dto.psikolog_adi=randevuKayıt.psikolog_adi;

            return View(dto);
           
        }
        [HttpPost]  
        public IActionResult Update(AppointmentUpdateDTO appointmentUpdateDTO)
        {

            RandevuKayıt randevuKayıt=new RandevuKayıt();
            randevuKayıt.randevu_bitis_tarihi = appointmentUpdateDTO.randevu_baslangic_tarihi;
            randevuKayıt.randevu_baslangic_tarihi = appointmentUpdateDTO.randevu_baslangic_tarihi;
            randevuKayıt.hasta_bilgi=appointmentUpdateDTO.hasta_bilgi;
            randevuKayıt.HizmetId=appointmentUpdateDTO.HizmetId;
            randevuKayıt.Id=appointmentUpdateDTO.Id;
            randevuKayıt.KullaniciId=appointmentUpdateDTO.KullaniciId;
            randevuKayıt.psikolog_adi=appointmentUpdateDTO.psikolog_adi; // Stringt'ten int'e çevirmeyi unutma
            _randevuKayitRepository.Update(randevuKayıt);


            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
           RandevuKayıt randevuKayıt= _randevuKayitRepository.GetByID(id);
            if (randevuKayıt==null)
                return RedirectToAction("Index");


            _randevuKayitRepository.Delete(randevuKayıt);
            return RedirectToAction("Index");   
        }

    }

}
