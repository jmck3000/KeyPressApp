using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressApp.Model
{
    public class Settings
    {
        public string AppName { get; set; }

        public string  KeyToPress { get; set; }

        public int SecoundsPerPress { get; set; }

        public int NumberOfTimes { get; set; }
    }
}
