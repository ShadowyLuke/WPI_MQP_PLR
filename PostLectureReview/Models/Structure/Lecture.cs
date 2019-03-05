using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostLectureReview.Models.Structure
{
    public partial class Lecture
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }        
        public String Code { get; set; }
        public String Title { get; set; }
        public String URLCode { get; set; }

        public ICollection<Topic> Topics { get; set; }
        public ICollection<Question> Questions { get; set; }

        // Internal Methods
        internal void AddTopics(int count = 1)
        {
            for (int i=0; i<count; i++)
            {
                Topics.Add(new Topic());
            }
        }

        internal void AddQuestions(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Questions.Add(new Question());
            }
        }
    }
}
