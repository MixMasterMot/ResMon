using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMonHost.Models
{
    public class CpuModel
    {
        public string Name { get; set; } = "Generic";
        public float Temperature { get; set; }
        public float Load { get; set; }
    }
}
