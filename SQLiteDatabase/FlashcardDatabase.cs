using SQLite;
using NuGet.Common;
using FlashCardsWPF.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace FlashCardsWPF.SQLiteDatabase
{
    public class FlashcardDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<FlashcardDatabase> Instance = new AsyncLazy<FlashcardDatabase>(async () =>
        {
            var instance = new FlashcardDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Flashcard>();
            return instance;
        });

        public FlashcardDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabaseFilename, Constants.Flags);
        }

        public async void CheckoutColumnNames()
        {
            var tableInfo = await Database.GetTableInfoAsync("Flashcard");

            Console.WriteLine(tableInfo);
            Console.WriteLine("Done");
        }

        public Task<Flashcard> GetItemAsync(int ID)
        {
            return Database.Table<Flashcard>().Where(x => x.ID == ID).FirstOrDefaultAsync();
        }

        public List<string> GetUniqueTopics()
        {
            List<string> result = new List<string>();

            List<Flashcard> resultingFlashcards = Database.QueryAsync<Flashcard>("SELECT DISTINCT Topic FROM [Flashcard]").Result;

            foreach (Flashcard flashcard in resultingFlashcards)
            {
                result.Add(flashcard.Topic);
            }

            return result;
        }

        public List<string> GetQuestionsByTopic(string topic)
        {
            List<string> result = new List<string>();

            List<Flashcard> resultingFlashcards = Database.QueryAsync<Flashcard>("SELECT Question FROM [Flashcard] WHERE Topic == ?", topic).Result;

            foreach (Flashcard flashcard in resultingFlashcards)
            {
                result.Add(flashcard.Question);
            }

            return result;
        }
        public List<string> GetAnswersByTopic(string topic)
        {
            List<string> result = new List<string>();

            List<Flashcard> resultingFlashcards = Database.QueryAsync<Flashcard>("SELECT Answer FROM [Flashcard] WHERE Topic == ?", topic).Result;

            foreach (Flashcard flashcard in resultingFlashcards)
            {
                result.Add(flashcard.Answer);
            }

            return result;
        }

        public int GetNumberOfQuestionsByTopic(string topic)
        {
            return GetQuestionsByTopic(topic).Count;
        }

        public Task<List<Flashcard>> GetItemsAsync()
        {
            return Database.Table<Flashcard>().ToListAsync();
        }

        public Task<List<Flashcard>> GetItemsByTopicAsync(string topicName)
        {
            return Database.Table<Flashcard>().Where(x => x.Topic == topicName).ToListAsync();
        }

        public Task<int> SaveItemAsync(Flashcard flashcard)
        {
            if (flashcard.ID != 0)
            {
                return Database.UpdateAsync(flashcard);
            }
            else
            {
                return Database.InsertAsync(flashcard);
            }
        }

        public Task<int> DeleteItemAsync(Flashcard flashcard)
        {
            return Database.DeleteAsync(flashcard);
        }

        public async Task DeleteItemAsync(string topic, string question)
        {
            await Database.QueryAsync<Flashcard>("DELETE FROM [Flashcard] WHERE topic == ? AND question == ?", topic, question);
        }

        public async Task DeleteTopicAsync(string topic)
        {
            await Database.QueryAsync<Flashcard>("DELETE FROM [Flashcard] WHERE topic == ?", topic);
        }

        public async Task<int> DropTableAsync()
        {
            return await Database.DropTableAsync<Flashcard>();
        }
    }
}