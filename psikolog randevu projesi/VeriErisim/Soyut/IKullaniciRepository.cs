using psikolog_randevu_projesi.Models;

namespace psikolog_randevu_projesi.VeriErisim.Soyut
{
    public interface IKullaniciRepository : IGenericRepository<Kullanici>
    {
        Kullanici GetByMail(string mail);
    }
}
