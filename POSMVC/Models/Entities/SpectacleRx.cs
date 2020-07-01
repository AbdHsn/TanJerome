using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class SpectacleRx
    {
        public long Id { get; set; }
        public string Nprsph { get; set; }
        public string Nprcyl { get; set; }
        public string Npraxis { get; set; }
        public string Nprva { get; set; }
        public string Npradd { get; set; }
        public string Nplsph { get; set; }
        public string Nplcyl { get; set; }
        public string Nplaxis { get; set; }
        public string Nplva { get; set; }
        public string Npladd { get; set; }
        public string NearRsph { get; set; }
        public string NearRcyl { get; set; }
        public string NearRaxis { get; set; }
        public string NearRva { get; set; }
        public string NearRadd { get; set; }
        public string NearLsph { get; set; }
        public string NearLcyl { get; set; }
        public string NearLaxis { get; set; }
        public string NearLva { get; set; }
        public string NearLadd { get; set; }
        public string Oprsph { get; set; }
        public string Oprcyl { get; set; }
        public string Opraxis { get; set; }
        public string Oprva { get; set; }
        public string Oplsph { get; set; }
        public string Oplcyl { get; set; }
        public string Oplaxis { get; set; }
        public string Oplva { get; set; }
        public string Rbc { get; set; }
        public string Lbc { get; set; }
        public string PupilHeight { get; set; }
        public string FrameSize { get; set; }
        public string Ed { get; set; }
        public string Adimension { get; set; }
        public string Bdimension { get; set; }
        public string Rpd { get; set; }
        public string Lpd { get; set; }
        public string NearFarPd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public long? CheckedBy { get; set; }
        public DateTime? CheckedDate { get; set; }
    }
}
