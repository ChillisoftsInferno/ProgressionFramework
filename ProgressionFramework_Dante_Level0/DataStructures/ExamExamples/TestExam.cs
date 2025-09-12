using FluentAssertions;

namespace ProgressionFramework_Dante_Level0.DataStructures.ExamExamples;

[TestFixture]
public class TestExam
{
    [TestFixture]
    public class TestExamData
    {
        [Test]
        public void ShouldAllowAddingQuestionsToExamQuestions()
        {
            //Arrange
            var exam = new Exam
            {
                ExamQuestions = new Dictionary<int, Dictionary<List<string>, List<string>>>()
            };

            var questions = new List<string>
            {
                "What is 2+2?", "What is 3+3?"
            };
            var answers = new List<string>
            {
                "4", "6"
            };
            var innerDict = new Dictionary<List<string>, List<string>>
            {
                {
                    questions, answers
                }
            };

            //Act
            exam.ExamQuestions.Add(1, innerDict);

            //Assert
            exam.ExamQuestions.Should().ContainKey(1);
            var storedQuestions = exam.ExamQuestions[1].Keys.First();
            storedQuestions.Should().Contain("What is 2+2?");
            exam.ExamQuestions[1][storedQuestions].Should().Contain("4");
        }

        [Test]
        public void ShouldOverwriteQuestions_WhenSameKeyIsUsed()
        {
            //Arrange
            var exam = new Exam
            {
                ExamQuestions = new Dictionary<int, Dictionary<List<string>, List<string>>>()
            };

            var original = new Dictionary<List<string>, List<string>>
            {
                {
                    new List<string>
                    {
                        "Q1"
                    },
                    new List<string>
                    {
                        "A1"
                    }
                }
            };
            var replacement = new Dictionary<List<string>, List<string>>
            {
                {
                    new List<string>
                    {
                        "Q2"
                    },
                    new List<string>
                    {
                        "A2"
                    }
                }
            };

            exam.ExamQuestions[1] = original;

            //Act
            exam.ExamQuestions[1] = replacement;

            //Assert
            exam.ExamQuestions[1].Keys.First().Should().Contain("Q2");
            exam.ExamQuestions[1].Values.First().Should().Contain("A2");
        }

        [Test]
        public void ShouldCreateExam_WithDefaultValues()
        {
            //Arrange
            var exam = ExamBuilder.Create().Build();

            //Act
            //Assert
            exam.ExamId.Should().NotBe(Guid.Empty);
            exam.StudentName.Should().Be("Default Student");
            exam.ExaminatorName.Should().Be("Default Examinator");
            exam.ExaminationDate.Should().Be(DateTime.Today);
            exam.YearMarkValue.Should().Be(0);
            exam.ExamQuestions.Should().BeEmpty();
        }

        [Test]
        public void ShouldSetStudentName()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .WithStudentName("Alice")
                .Build();

            //Act
            //Assert
            exam.StudentName.Should().Be("Alice");
        }

        [Test]
        public void ShouldSetExaminatorName()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .WithExaminatorName("Professor Smith")
                .Build();

            //Act
            //Assert
            exam.ExaminatorName.Should().Be("Professor Smith");
        }

        [Test]
        public void ShouldSetExaminationDate()
        {
            //Arrange
            var date = new DateTime(2025, 9, 11);
            var exam = ExamBuilder.Create()
                .WithExaminationDate(date)
                .Build();

            //Act
            //Assert
            exam.ExaminationDate.Should().Be(date);
        }

        [Test]
        public void ShouldSetYearMarkValue()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .WithYearMarkValue(85)
                .Build();

            //Act
            //Assert
            exam.YearMarkValue.Should().Be(85);
        }

        [Test]
        public void ShouldAddExamQuestions()
        {
            //Arrange
            var questions = new List<string>
            {
                "Q1", "Q2"
            };
            var answers = new List<string>
            {
                "A1", "A2"
            };

            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, questions, answers)
                .Build();

            //Act
            var section = exam.ExamQuestions[1];

            //Assert
            section.Should().ContainKey(questions);
            section[questions].Should().BeEquivalentTo(answers);
        }

        [Test]
        public void ShouldAllowMultipleSections()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, new List<string>
                {
                    "Q1"
                }, new List<string>
                {
                    "A1"
                })
                .AddExamQuestion(2, new List<string>
                {
                    "Q2"
                }, new List<string>
                {
                    "A2"
                })
                .Build();

            //Act
            //Assert
            exam.ExamQuestions.Should().ContainKeys(1, 2);
            exam.ExamQuestions[1].Keys.Should().ContainSingle();
            exam.ExamQuestions[2].Keys.Should().ContainSingle();
        }
    }

    [TestFixture]
    public class TestExamLinqExtensions
    {
        [Test]
        public void ShouldFilterExams_ByStudentName()
        {
            //Arrange
            var exams = new List<Exam>
            {
                ExamBuilder.Create().WithStudentName("Alice").Build(),
                ExamBuilder.Create().WithStudentName("Bob").Build(),
                ExamBuilder.Create().WithStudentName("Charlie").Build()
            };

            //Act
            var result = exams.Where(e => e.StudentName.StartsWith("A")).ToList();

            //Assert
            result.Should().ContainSingle();
            result.First().StudentName.Should().Be("Alice");
        }

        [Test]
        public void ShouldSelectExaminatorNames()
        {
            //Arrange
            var exams = new List<Exam>
            {
                ExamBuilder.Create().WithExaminatorName("Prof. Smith").Build(),
                ExamBuilder.Create().WithExaminatorName("Dr. Jones").Build()
            };

            //Act
            var names = exams.Select(e => e.ExaminatorName).ToList();

            //Assert
            names.Should().Contain(new[] { "Prof. Smith", "Dr. Jones" });
        }

        [Test]
        public void ShouldOrderExams_ByYearMark()
        {
            //Arrange
            var exams = new List<Exam>
            {
                ExamBuilder.Create().WithYearMarkValue(75).Build(),
                ExamBuilder.Create().WithYearMarkValue(90).Build(),
                ExamBuilder.Create().WithYearMarkValue(60).Build()
            };

            //Act
            var ordered = exams.OrderByDescending(e => e.YearMarkValue).ToList();

            //Assert
            ordered.First().YearMarkValue.Should().Be(90);
            ordered.Last().YearMarkValue.Should().Be(60);
        }

        [Test]
        public void ShouldFindExam_ById()
        {
            //Arrange
            var idToFind = Guid.NewGuid();
            var exams = new List<Exam>
            {
                ExamBuilder.Create().WithExamId(idToFind).Build(),
                ExamBuilder.Create().WithExamId(Guid.NewGuid()).Build()
            };

            //Act
            var foundExam = exams.FirstOrDefault(e => e.ExamId == idToFind);

            //Assert
            foundExam.Should().NotBeNull();
            foundExam!.ExamId.Should().Be(idToFind);
        }

        [Test]
        public void ShouldCountExams_WithYearMarkAboveThreshold()
        {
            //Arrange
            var exams = new List<Exam>
            {
                ExamBuilder.Create().WithYearMarkValue(40).Build(),
                ExamBuilder.Create().WithYearMarkValue(85).Build(),
                ExamBuilder.Create().WithYearMarkValue(90).Build()
            };

            //Act
            var count = exams.Count(e => e.YearMarkValue >= 50);

            //Assert
            count.Should().Be(2);
        }

        [Test]
        public void ShouldVerifyAnyExam_HasQuestions()
        {
            //Arrange
            var exams = new List<Exam>
            {
                ExamBuilder.Create().Build(),
                ExamBuilder.Create()
                    .AddExamQuestion(1, new List<string>{"Q1"}, new List<string>{"A1"})
                    .Build()
            };

            //Act
            var anyWithQuestions = exams.Any(e => e.ExamQuestions.Count > 0);

            //Assert
            anyWithQuestions.Should().BeTrue();
        }
    }
    
    [TestFixture]
    public class TestExamDictionaryExtensions
    {
        [Test]
        public void ShouldVerifyDictionaryContainsSection()
        {
            //Arrange
            var questions = new List<string> { "Q1" };
            var answers = new List<string> { "A1" };

            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, questions, answers)
                .Build();

            //Act
            var containsKey = exam.ExamQuestions.ContainsKey(1);

            //Assert
            containsKey.Should().BeTrue();
        }

        [Test]
        public void ShouldVerifyDictionaryDoesNotContainSection()
        {
            //Arrange
            var exam = ExamBuilder.Create().Build();

            //Act
            var containsKey = exam.ExamQuestions.ContainsKey(99);

            //Assert
            containsKey.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnAllKeys()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, new List<string> { "Q1" }, new List<string> { "A1" })
                .AddExamQuestion(2, new List<string> { "Q2" }, new List<string> { "A2" })
                .Build();

            //Act
            var keys = exam.ExamQuestions.Keys.ToList();

            //Assert
            keys.Should().Contain(new[] { 1, 2 });
        }

        [Test]
        public void ShouldReturnAllValues()
        {
            //Arrange
            var q1 = new List<string> { "Q1" };
            var a1 = new List<string> { "A1" };
            var q2 = new List<string> { "Q2" };
            var a2 = new List<string> { "A2" };

            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, q1, a1)
                .AddExamQuestion(2, q2, a2)
                .Build();

            //Act
            var values = exam.ExamQuestions.Values.ToList();

            //Assert
            values.Should().Contain(v => v.ContainsKey(q1) && v[q1].Contains("A1"));
            values.Should().Contain(v => v.ContainsKey(q2) && v[q2].Contains("A2"));
        }

        [Test]
        public void ShouldCountNumberOfSections()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, new List<string> { "Q1" }, new List<string> { "A1" })
                .AddExamQuestion(2, new List<string> { "Q2" }, new List<string> { "A2" })
                .Build();

            //Act
            var count = exam.ExamQuestions.Count;

            //Assert
            count.Should().Be(2);
        }

        [Test]
        public void ShouldSelectAllQuestionsAcrossSections()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, new List<string> { "Q1", "Q2" }, new List<string> { "A1", "A2" })
                .AddExamQuestion(2, new List<string> { "Q3" }, new List<string> { "A3" })
                .Build();

            //Act
            var allQuestions = exam.ExamQuestions
                .SelectMany(section => section.Value.Keys.SelectMany(qList => qList))
                .ToList();

            //Assert
            allQuestions.Should().Contain(new[] { "Q1", "Q2", "Q3" });
        }

        [Test]
        public void ShouldVerifyAnySectionContainsSpecificQuestion()
        {
            //Arrange
            var exam = ExamBuilder.Create()
                .AddExamQuestion(1, new List<string> { "Q1", "Q2" }, new List<string> { "A1", "A2" })
                .Build();

            //Act
            var containsQ2 = exam.ExamQuestions
                .Any(section => section.Value.Keys.Any(qlist => qlist.Contains("Q2")));

            //Assert
            containsQ2.Should().BeTrue();
        }
    }
}
