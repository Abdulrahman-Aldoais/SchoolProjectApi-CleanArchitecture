using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{

    public class DepartmetSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeptSubID { get; set; }
        public Guid DID { get; set; }
        public Guid SubID { get; set; }

        [ForeignKey("DID")]
        public virtual Department? Department { get; set; }

        [ForeignKey("SubID")]
        public virtual Subject? Subject { get; set; }
    }

}
