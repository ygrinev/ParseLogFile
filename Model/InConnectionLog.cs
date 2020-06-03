using System;
using System.Collections.Generic;
using System.Text;

namespace ParseLogFile.Model
{
    public class InConnectionLog
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string srcIp { get; set; }
        public string dstIp { get; set; }
        public DateTime dTime { get; set; }
        public int logId { get; set; }

    }
}
