using System;
using System.Collections.Generic;
using System.Text;

namespace ResMonClientTst.Models
{
    public class RamModel
    {
        public string Name { get; set; } = "Generic Ram";
        public float MemoryUsed { get; set; }
        public float MemoryFree { get; set; }
        public float MemoryTotal { get; set; }
        public float Load { get; set; }
    }
}
