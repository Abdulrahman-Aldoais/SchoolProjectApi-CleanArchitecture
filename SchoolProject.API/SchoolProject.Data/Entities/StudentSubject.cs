using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudSubID { get; set; }
        public Guid StudID { get; set; }
        public Guid SubID { get; set; }

        [ForeignKey("StudID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        public virtual Subject? Subject { get; set; }

    }

}
