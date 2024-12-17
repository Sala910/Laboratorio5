using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    // Интерфейс устройства
    public interface IDevice
    {
        void Print(string data);
    }

    // Конкретные устройства
    public class Monitor : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine($"Displaying on monitor: {data}");
        }
    }

    public class Printer : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine($"Printing: {data}");
        }
    }

    // Абстракция
    public abstract class Output
    {
        protected IDevice device;

        public Output(IDevice device)
        {
            this.device = device;
        }

        public abstract void Render(string data);
    }

    // Конкретные реализации абстракции
    public class TextOutput : Output
    {
        public TextOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            device.Print($"Text: {data}");
        }
    }

    public class ImageOutput : Output
    {
        public ImageOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            device.Print($"Image: {data}");
        }
    }

}
