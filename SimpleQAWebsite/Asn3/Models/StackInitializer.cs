using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asn3.Models
{
    public class StackInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StackContext>
    {
        protected override void Seed(StackContext context)
        {
            var questions = new List<Question>
            {
            new Question{Qid=123,Qname="what is this",Qdatetime=DateTime.Today.ToString(),Categoryid=12,Catobjref="tt"},
            };

            questions.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
            new Category{CategoryId=12,CategoryName="what is this"},
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
        }
    }
}