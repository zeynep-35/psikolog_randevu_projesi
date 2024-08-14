namespace psikolog_randevu_projesi.Models
{
    public class hizmet
    {
        public int Id { get; set; }
        public string hizmet_adi { get; set; }
        public int hizmet_suresi { get; set; }
        public string psikolog_iletisim_bilgileri { get; set; }
        public int hizmet_ucreti { get; set; }
        public ICollection<RandevuKayıt> RandevuKayıtları { get; set; }

    }
}
