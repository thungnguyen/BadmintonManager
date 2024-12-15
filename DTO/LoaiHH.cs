using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class LoaiHH
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int MaLoaiHH { get; set; }
        public string TenLoaiHH { get; set; }
    }

}
