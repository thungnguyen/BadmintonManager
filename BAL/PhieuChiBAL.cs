using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace BadmintonManager.BAL
{
    public class PhieuChiBAL
    {
        private PhieuChiDAL phieuChiDAL;

        public PhieuChiBAL()
        {
            phieuChiDAL = new PhieuChiDAL();
        }

        public bool LuuPhieuChi(PhieuChiDTO phieuChi)
        {
            return phieuChiDAL.ThemPhieuChi(phieuChi);
        }
    }
}
