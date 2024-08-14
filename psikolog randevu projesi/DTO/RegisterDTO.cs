using Microsoft.CodeAnalysis.Emit;

namespace psikolog_randevu_projesi.DTO
{
    public class RegisterDTO
    {
        public string kullaniici_adi { get; set; } 
        public string sifre { get; set; }
        public string tc_kimlik_numarasi { get; set; }
        public string ad_soyad { get; set; }
        public string e_posta { get; set; }
        public string tel_nu { get; set; }
    }
}
