
using System.Collections.Generic;

namespace AndroidXamarinApp.Data
{
    class Quiz
    {
        public static QuizState quizState;

        public static bool IsCorrectOption(Option option) => quizState.getCurrentQuestion().CorrectOptionNumber == option.Number;
    }

    class QuizState
    {
        public List<Question> Questions { get; set; }
        public int CurrentQuestionNumber { get; set; }
        
        public int PassedQuestionsCount { get; set; }
        public int CorrectQuestionsCount { get; set; }
        public int FailedQuestionsCount { get; set; }

        public QuizState(List<Question> questions)
        {
            Questions = questions;
            CurrentQuestionNumber = 0;
            PassedQuestionsCount = 0;
            FailedQuestionsCount = 0;
            CorrectQuestionsCount = 0;
        }

        public Question getCurrentQuestion() => Questions[CurrentQuestionNumber];
    }
}