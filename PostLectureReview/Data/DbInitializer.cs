using PostLectureReview.Models;
using PostLectureReview.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostLectureReview.Data
{
    public class DbInitializer
    {
        public static void Initialize(DevelopmentContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Lectures
            if (context.Lectures.Any())
            {
                return; // DB has been seeded
            }

            var lectures = new Lecture[]
            {
                new Lecture{Code="1", Title="Introduction", URLCode="http://localhost", Date=DateTime.Parse("2018-6-11")},
                new Lecture{Code="2.1", Title="Approach", URLCode="http://localhost", Date=DateTime.Parse("2018-7-11")},
                new Lecture{Code="2.2", Title="Initial Techniques", URLCode="http://localhost", Date=DateTime.Parse("2018-8-11")},
                new Lecture{Code="3", Title="Examples", URLCode="http://localhost", Date=DateTime.Parse("2018-9-11")}
            };
            foreach (Lecture l in lectures)
            {
                context.Lectures.Add(l);
            }
            context.SaveChanges();

            var topics = new Topic[]
            {
                new Topic{LectureID=2, Title="Simple Approach"},
                new Topic{LectureID=2, Title="Complex Approach"},
                new Topic{LectureID=3, Title="Basics"},
                new Topic{LectureID=3, ParentID=3, Title="Parsing"},
                new Topic{LectureID=3, ParentID=3, Title="Interpretation"},
                new Topic{LectureID=4, Title="Simple Example"},
                new Topic{LectureID=4, Title="Confusing Example"},
                new Topic{LectureID=4, ParentID=7, Title="Identifying Sections"},
                new Topic{LectureID=4, ParentID=7, Title="Running Through"},
                new Topic{LectureID=4, Title="Complex Example"},
                new Topic{LectureID=4, ParentID=10, Title="Approach"}
            };
            foreach (Topic t in topics)
            {
                context.Topics.Add(t);
            }
            context.SaveChanges();

            var questions = new Question[]
            {
                new Question{LectureID=1, Text="Any additional Questions about Course Structure?"},
                new Question{LectureID=1, Text="Any additional Questions about the Course?"},
                new Question{LectureID=1, Text="Any additional concerns?"},
                new Question{LectureID=2, Text="Any concerns about this Lecture?"},
                new Question{LectureID=4, Text="Any particular doubts about the Examples?"}
            };
            foreach (Question q in questions)
            {
                context.Questions.Add(q);
            }
            context.SaveChanges();
        }
    }
}
