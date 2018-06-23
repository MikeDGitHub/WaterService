using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class AppSettings
    {
      public Logging Logging { get; set; }
      public string ConnectionStrings { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
    }
}
