﻿using SQLite;

namespace v2rayN.Mode
{
    [Serializable]
    public class DNSItem
    {
        [PrimaryKey]
        public string id { get; set; }

        public string remarks { get; set; }
        public bool enabled { get; set; } = true;
        public ECoreType coreType { get; set; }
        public string? normalDNS { get; set; }
        public string? directDNS { get; set; }
        public string? proxyDNS { get; set; }
        public string? domainStrategy4Freedom { get; set; }
    }
}