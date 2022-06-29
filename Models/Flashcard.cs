using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace FlashCardsWPF.Models
{
    [Table("Flashcard")]
    public class Flashcard
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Topic { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime LatestStudied { get; set; }
        public int NumberOfCorrectRepetitions { get; set; }

        // Constructors
        public Flashcard() { }

        public Flashcard(string Topic, string Question, string Answer)
        {
            this.Topic = Topic;
            this.Question = Question;
            this.Answer = Answer;  
        }
    }
}