using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ResMonClientTst.Models
{
    public class CpuModel
    {
        public string Name { get; set; } = "Generic CPU";
        public float Temperature { get; set; }
        public float Load { get; set; }

    }
}
