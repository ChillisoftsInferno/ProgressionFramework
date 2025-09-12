namespace ProgressionFramework_Dante_Level0.DataStructures.ExamExamples;

public class ExamBuilder
{
    private Exam _exam;

    private ExamBuilder()
    {
        _exam = new Exam
        {
            ExamId = Guid.NewGuid(),
            ExamQuestions = new Dictionary<int, Dictionary<List<string>, List<string>>>(),
            StudentName = "Default Student",
            ExaminatorName = "Default Examinator",
            ExaminationDate = DateTime.Today,
            YearMarkValue = 0
        };
    }

    public static ExamBuilder Create()
    {
        return new ExamBuilder();
    }

    public ExamBuilder WithExamId(Guid id)
    {
        _exam.ExamId = id;
        return this;
    }

    public ExamBuilder WithStudentName(string studentName)
    {
        _exam.StudentName = studentName;
        return this;
    }

    public ExamBuilder WithExaminatorName(string examinatorName)
    {
        _exam.ExaminatorName = examinatorName;
        return this;
    }

    public ExamBuilder WithExaminationDate(DateTime date)
    {
        _exam.ExaminationDate = date;
        return this;
    }

    public ExamBuilder WithYearMarkValue(int value)
    {
        _exam.YearMarkValue = value;
        return this;
    }

    public ExamBuilder AddExamQuestion(int sectionNumber, List<string> questions, List<string> answers)
    {
        if (!_exam.ExamQuestions.ContainsKey(sectionNumber))
        {
            _exam.ExamQuestions[sectionNumber] = new Dictionary<List<string>, List<string>>();
        }

        _exam.ExamQuestions[sectionNumber][questions] = answers;
        return this;
    }

    public Exam Build()
    {
        return _exam;
    }
}
