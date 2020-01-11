using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asn3.Models
{
    public class Answer
    {
        public Answer()
        {

        }
        public Answer(int id,string text)
        {
            QuestionId = id;
            AnswerText = text;
            AnswerDateTime = DateTime.Today.ToString();
        }
        [Key]
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [Display(Name = "Answer")]
        public string AnswerText { get; set; }

        [Display(Name = "Date and Time")]
        public string AnswerDateTime { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}