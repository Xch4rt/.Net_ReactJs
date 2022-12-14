using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetReactJs.Models
{
    public class DCandidate
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(16)")]

        public string mobile { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string email { get; set; }

        public int age { get; set; }
        [Column(TypeName = "nvarchar(3)")]

        public string bloodGroup { get; set; }
        [Column(TypeName = "nvarchar(256)")]

        public string address { get; set; }
    }
}
