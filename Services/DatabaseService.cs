using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class DatabaseService
	{
		private const string ConnectionString =
			"Data Source=Data/database.db;Version=3;";
		public void InitializeDatabase()
		{
			using (var connection = new SqliteConnection(ConnectionString))
			{
				connection.Open();

				string createTableQuery = @"
				CREATE TYPE EMOTION AS ENUM (
				'Happy',
				'Energized',
				'Tired',
				'Anxious',
				'Stressed',
				'Sad',
				'Annoyed',
				'Neutral'
				);
				CREATE TABLE IF NOT EXISTS DiaryEntries (
				Id LONG PRIMARY KEY AUTOINCREMENT,
				Title TEXT, 
				Content	TEXT NOT NULL,
				Emotion TEXT NOT NULL,
				Date TEXT NOT NULL,
				IsPublic BOOLEAN DEFAULT FALSE
				);";

				using var command = new SQLiteCommand(createTableQuery, connection);
				command.ExecuteNonQuery();
			}
		}

		public bool TestConnection()
		{
			try
			{
				using (var connection = new SqliteConnection(ConnectionString))
				{
					connection.Open();
					return true;
				}
			}
			catch 
			{
				return false;
			}
		}
	}
}
