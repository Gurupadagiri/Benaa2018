using System;

namespace Benaa2018.Data.Model
{
    public class BaseModel
    {
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
