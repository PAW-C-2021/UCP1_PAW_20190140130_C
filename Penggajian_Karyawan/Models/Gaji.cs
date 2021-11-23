using System;
using System.Collections.Generic;

#nullable disable

namespace Penggajian_Karyawan.Models
{
    public partial class Gaji
    {
        public int IdGaji { get; set; }
        public string Nama { get; set; }
        public int? IdPegawai { get; set; }
        public int? IdGolongan { get; set; }
        public string Tunjangan { get; set; }
        public string Potongan { get; set; }
        public int? Total { get; set; }
    }
}
