using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WGetAnalogue.Library.Models
{
    public class ContentModel
    {
        public byte[] Content { get; set; }
        public string CharSet { get; set; }
        public string Type { get; set; }
    }
}
