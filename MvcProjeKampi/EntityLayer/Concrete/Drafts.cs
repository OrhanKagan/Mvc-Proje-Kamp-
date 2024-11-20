using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Drafts
    {
        [Key]
        public int DraftsID { get; set; }

        [StringLength(50)]
        public string DraftsReceiverMail { get; set; }

        [StringLength(100)]
        public string DraftsSubject { get; set; }

        public string DraftsMessageContent { get; set; }

        public bool DraftsStatus { get; set; }

        public DateTime DraftsDate { get; set; }
    }
}
