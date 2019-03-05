using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostLectureReview.Models.Structure
{
    public class Topic
    {
        // Constructors
        public Topic()
        {
            this.DeleteTopic = false;
        }

        // Variables
        public int ID { get; set; }
        public int LectureID { get; set; }
        public int? ParentID { get; set; }

        public Lecture Lecture { get; set; }
        public Topic Parent { get; set; }

        public String Title { get; set; }
        public bool DeleteTopic { get; set; }

        public ICollection<Topic> SubTopics { get; set; }
    }
}