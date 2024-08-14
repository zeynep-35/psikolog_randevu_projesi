namespace psikolog_randevu_projesi.Models
{
    public class RandevuKayıt
    {
        public int Id { get; set; }
        public string psikolog_adi { get; set; }
        public DateTime randevu_baslangic_tarihi { get; set; }
        public DateTime randevu_bitis_tarihi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int HizmetId { get; set; }
        public hizmet Hizmet { get; set; }
        public string hasta_bilgi { get; set; }
    }
}
