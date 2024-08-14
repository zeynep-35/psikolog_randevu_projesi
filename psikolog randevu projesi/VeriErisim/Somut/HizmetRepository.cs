using psikolog_randevu_projesi.Context;
using psikolog_randevu_projesi.Models;
using psikolog_randevu_projesi.VeriErisim.Soyut;

namespace psikolog_randevu_projesi.VeriErisim.Somut
{
    public class HizmetRepository : GenericRepository<hizmet>, IHizmetRepository
    {
        public HizmetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
