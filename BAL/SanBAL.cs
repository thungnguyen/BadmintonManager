using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.BAL
{
    public class SanBAL
    {
        private SanDAL sanDAL;

        public SanBAL()
        {
            sanDAL = new SanDAL();
        }

        public List<SanDTO> GetAllSans()
        {
            return sanDAL.GetSanList();
        }
    }
}
