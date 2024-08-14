using psikolog_randevu_projesi.Context;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Soyut;

namespace psikolog_randevu_projesi.VeriErisim.Somut
{
    public class KullaniciRepository : GenericRepository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici GetByMail(string mail)
        {
            Kullanici kullanici = _context.Kullanicilar.Where(kullanici=>kullanici.e_posta==mail).FirstOrDefault();
            return kullanici;
        }
    }
}
