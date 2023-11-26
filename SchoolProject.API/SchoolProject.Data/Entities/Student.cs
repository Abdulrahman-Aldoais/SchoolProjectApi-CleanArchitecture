using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        [StringLength(100)]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string NameEn { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudID { get; set; }
        [StringLength(300)]
        public string? Address { get; set; }
        [StringLength(100)]
        public string? Phone { get; set; }
        public Guid? DID { get; set; }
        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
    }
}
