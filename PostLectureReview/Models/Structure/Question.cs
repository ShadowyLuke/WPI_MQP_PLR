using System;
using System.ComponentModel.DataAnnotations;

namespace PostLectureReview.Models.Structure
{
    public class Question
    {
        // Constructors
        public Question()
        {
            this.DeleteQuestion = false;
        }

        // Variables
        public int ID { get; set; }
        public int LectureID { get; set; }

        public Lecture Parent { get; set; }

        public String Text { get; set; }

        public bool DeleteQuestion { get; set; }
    }
}