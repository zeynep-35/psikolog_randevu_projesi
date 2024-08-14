using psikolog_randevu_projesi.Context;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Soyut;

namespace psikolog_randevu_projesi.VeriErisim.Somut
{
    public class RandevuKayitRepository : GenericRepository<RandevuKayıt>, IRandevuKayitRepository
    {
        public RandevuKayitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
