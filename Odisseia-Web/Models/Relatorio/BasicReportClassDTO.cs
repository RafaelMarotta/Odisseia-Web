using System;

namespace Models.Relatorio
{
    public class BasicReportClassDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double RightAverage { get; set; }
        public double WrongAverage { get; set; }
        public TimeSpan TimeAverage { get; set; }
    }
}
