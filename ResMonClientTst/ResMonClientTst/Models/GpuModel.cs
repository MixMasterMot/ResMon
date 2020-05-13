using System;
using System.Collections.Generic;
using System.Text;

namespace ResMonClientTst.Models
{
    public class GpuModel
    {
        public string Name { get; set; } = "Generic GPU";
        public float Load { get; set; }
        public float Temperature { get; set; }
        public float MemoryTotal { get; set; }
        public float MemoryUsed { get; set; }
        public float MemoryFree { get; set; }

    }
}
