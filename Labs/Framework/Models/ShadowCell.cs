using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class ShadowCell
    {
        public SurfaceCell Cell { get; set; }
        public bool IsHidden { get; set; } = false;
    }
}
