using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E112.Models
{
    public class Sitios
    {
        public int id { get; set; }
        public byte[] foto { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string descripcion { get; set; }

    }
}
