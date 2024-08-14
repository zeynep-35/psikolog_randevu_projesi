using psikolog_randevu_projesi.Models;

namespace psikolog_randevu_projesi.DTO
{
    public class AppointmentCreateDTO
    {
        public string psikolog_adi { get; set; }


        public DateTime randevu_baslangic_tarihi { get; set; }
        public DateTime randevu_bitis_tarihi { get; set; }
        public int KullaniciId { get; set; }
   
        public int HizmetId { get; set; }
        
        public string hasta_bilgi { get; set; }
    }
}
