using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMonHost.Models
{
    public class Info
    {

        private List<CpuModel> _cpus = new List<CpuModel>();
        public List<CpuModel> cpus
        {
            get { return _cpus; }
            set
            {
                _cpus = value;
            }
        }

        private List<GpuModel> _gpus = new List<GpuModel>();
        public List<GpuModel> gpus
        {
            get { return _gpus; }
            set
            {
                _gpus = value;
            }
        }

        private List<RamModel> _rams = new List<RamModel>();
        public List<RamModel> rams
        {
            get { return _rams; }
            set
            {
                _rams = value;
            }
        }
        
    }
}
