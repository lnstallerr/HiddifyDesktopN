﻿namespace v2rayN.Mode
{
    [Serializable]
    internal class ServerSpeedItem : ServerStatItem
    {
        public long proxyUp
        {
            get; set;
        }

        public long proxyDown
        {
            get; set;
        }

        public long directUp
        {
            get; set;
        }

        public long directDown
        {
            get; set;
        }
    }
}