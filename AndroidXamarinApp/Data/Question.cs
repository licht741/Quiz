﻿using System.Collections.Generic;

namespace AndroidXamarinApp.Data
{
    class Question
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public List<Option> Options { get; set; }
        public int CorrectOptionNumber { get; set; }
        public string Text { get; set; }
    }

    public class Option
    {
        public int Number { get; set; }
        public string OptionText { get; set; }
    }
}