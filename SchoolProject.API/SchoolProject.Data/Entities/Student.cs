using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public Student()
        {

            this.StudID = new Guid();
        }

        public Student(Guid studID) : this()
        {
            StudID = studID;
        }
        [Key]
        public Guid StudID { get; set; }
        [StringLength(100)]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string NameEn { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }
        [StringLength(100)]
        public string? Phone { get; set; }
        public Guid? DID { get; set; }
        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
    }
}
