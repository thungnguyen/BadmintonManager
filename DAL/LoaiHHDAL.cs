using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    internal class LoaiHHDAL
    {
        private readonly MongoDBConnection _dbConnection; 

        public LoaiHHDAL()
        {
            _dbConnection = new MongoDBConnection();
        }


    }
}
