using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPEncDec
{
    public class UploadFile
    {
        internal string ICon;

        public string Filename { get; set; }
        public string FileExtension { get; set; }
        public long Size { get; set; }
        public string FilePath { get; set; }
        public string Icon { get; set; }
    }
}