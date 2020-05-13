using OpenHardwareMonitor.Hardware;
using ResourceMonHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMonHost.Monitor
{
    public class Monitor
    {
        public Info GetSystemInfo()
        {
            Info info = new Info();

            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.RAMEnabled = true;
            computer.GPUEnabled = true;
            computer.Accept(updateVisitor);

            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    CpuModel cpuModel = new CpuModel();
                    cpuModel.Name = computer.Hardware[i].Name;
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        // check temp
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "CPU Package")
                            {
                                cpuModel.Temperature = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check load
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "CPU Total")
                            {
                                cpuModel.Load = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }
                    }
                    info.cpus.Add(cpuModel);
                }

                if (computer.Hardware[i].HardwareType == HardwareType.RAM)
                {
                    RamModel ramModel = new RamModel();
                    ramModel.Name = computer.Hardware[i].Name;
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        // check load
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "Memory")
                            {
                                ramModel.Load = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check data
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Data)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "Used Memory")
                            {
                                ramModel.MemoryUsed = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                            else if (computer.Hardware[i].Sensors[j].Name == "Available Memory")
                            {
                                ramModel.MemoryFree = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }
                    }
                    ramModel.MemoryTotal = ramModel.MemoryUsed + ramModel.MemoryFree;
                    info.rams.Add(ramModel);
                }

                if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                {
                    GpuModel gpuModel = new GpuModel();
                    gpuModel.Name = computer.Hardware[i].Name;
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        // check temp
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Core")
                            {
                                gpuModel.Temperature = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check smallData
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.SmallData)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Total")
                            {
                                gpuModel.MemoryTotal = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                            else if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Used")
                            {
                                gpuModel.MemoryUsed = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                            else if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Free")
                            {
                                gpuModel.MemoryFree = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check load
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Memory")
                            {
                                gpuModel.Load = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }
                    }
                    info.gpus.Add(gpuModel);
                }

                if (computer.Hardware[i].HardwareType == HardwareType.GpuAti)
                {
                    GpuModel gpuModel = new GpuModel();
                    gpuModel.Name = computer.Hardware[i].Name;
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        // check temp
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Core")
                            {
                                gpuModel.Temperature = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check smallData
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.SmallData)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Total")
                            {
                                gpuModel.MemoryTotal = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                            else if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Used")
                            {
                                gpuModel.MemoryUsed = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                            else if (computer.Hardware[i].Sensors[j].Name == "GPU Memory Free")
                            {
                                gpuModel.MemoryFree = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }

                        // check load
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                        {
                            if (computer.Hardware[i].Sensors[j].Name == "GPU Memory")
                            {
                                gpuModel.Load = computer.Hardware[i].Sensors[j].Value ?? -1;
                            }
                        }
                    }
                    info.gpus.Add(gpuModel);
                }
            }
            computer.Close();

            return info;
        }
    }
}
