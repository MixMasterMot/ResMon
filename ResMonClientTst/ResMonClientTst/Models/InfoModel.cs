using System;
using System.Collections.Generic;
using System.Text;

namespace ResMonClientTst.Models
{
    public class InfoModel
    {
        public List<CpuModel> cpus { get; set; }
        public List<GpuModel> gpus { get; set; }
        public List<RamModel> rams { get; set; }
    }
}
