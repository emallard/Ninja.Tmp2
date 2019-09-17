using System;
using System.Collections.Generic;
using CocoriCore.Page;

namespace LeBonCoin
{
    public class TestLogger : IUserLogger
    {
        public List<object> Logs = new List<object>();
        public void Log(UserLog log)
        {
            Logs.Add(log);
        }
    }
}
