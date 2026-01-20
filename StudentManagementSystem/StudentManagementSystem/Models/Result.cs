using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int CreatedBy { get; set; } // TeacherId

        public int MarksObtained { get; set; }

        [StringLength(5)]
        public string Grade { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Teacher Teacher { get; set; }
    }
}
