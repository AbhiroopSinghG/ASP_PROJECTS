using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Asn3.Models
{
    public class Question
    {
        [Key]
        public int Qid { get; set; }
        [Display(Name = "Question")]
        public string Qname { get; set; }
        [Display(Name = "Queston date and time")]
        public string Qdatetime { get; set; }
        [Display(Name = "Category Id")]
        public int Categoryid { get; set; }

        [Display(Name = "Answers")]
        public string Catobjref { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }
}