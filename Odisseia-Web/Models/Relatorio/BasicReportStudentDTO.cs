using System;

namespace Models.Relatorio
{
    public class BasicReportStudentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double RightCount { get; set; }
        public double WrongCount { get; set; }
        public TimeSpan TimeSpent { get; set; }
    }
}
