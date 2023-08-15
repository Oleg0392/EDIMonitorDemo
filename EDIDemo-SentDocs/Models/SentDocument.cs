using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIMonitorDemoData.Models
{
    [Microsoft.EntityFrameworkCore.Keyless]
    public class SentDocument
    {
        [Required]
        [Column(TypeName = "bigint")]
        public int Doc { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? DopTxt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? DtVrOtpr { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? FLNm { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long IsProDoc { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? NmrDocIspro { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? Own { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public int SDoc { get; set; }

        [Required]
        [Column(TypeName = "decimal(21,2)")]
        public decimal SmDoc { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long ZakRcd { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long bookmark { get; set; }
    }
}
