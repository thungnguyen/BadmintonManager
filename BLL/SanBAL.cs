using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Bson;
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
            // Lấy danh sách BsonDocument từ DAL
            List<BsonDocument> sanListBson = sanDAL.GetSanList();

            // Chuyển đổi BsonDocument thành SanDTO
            List<SanDTO> sanDTOList = new List<SanDTO>();
            foreach (var item in sanListBson)
            {
                // Tạo đối tượng SanDTO từ BsonDocument
                SanDTO san = new SanDTO
                {
                    Id = item["_id"].ToString(),
                    MaSan = item["maSan"].AsInt32,
                    TenSan = item["tenSan"].AsString,
                    Status = item["status"].AsString
                };
                sanDTOList.Add(san);
            }
            return sanDTOList;
        }

    }
}
