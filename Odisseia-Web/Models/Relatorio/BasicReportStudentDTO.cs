using System;

namespace Models.Relatorio
{
    public class BasicReportStudentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int RightCount { get; set; }
        public int WrongCount { get; set; }
        public TimeSpan TimeSpent { get; set; }
    }
}
