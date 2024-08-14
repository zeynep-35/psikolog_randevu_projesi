namespace psikolog_randevu_projesi.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string kullaniici_adi { get; set; }
        public string sifre { get; set; }
        public string tc_kimlik_numarasi { get;set; }
        public string ad_soyad { get; set; }
        public string e_posta { get; set; }
        public string tel_nu { get; set; }
    }
}
