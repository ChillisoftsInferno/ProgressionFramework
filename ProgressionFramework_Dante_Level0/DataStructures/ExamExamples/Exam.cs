namespace ProgressionFramework_Dante_Level0.DataStructures.ExamExamples;

public class Exam
{
    public Guid ExamId { get; set; }
    public Dictionary<int, Dictionary<List<string>, List<string>>> ExamQuestions { get; set; } = null!;
    public string StudentName { get; set; } = null!;
    public string ExaminatorName { get; set; } = null!;
    public DateTime ExaminationDate { get; set; }
    public int YearMarkValue { get; set; }
}
