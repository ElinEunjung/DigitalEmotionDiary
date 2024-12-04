
using Microsoft.Data.Sqlite;

namespace DigitalEmotionDiary.Services
{
	internal class SQLiteCommand : IDisposable
	{
		public SQLiteCommand(string createTableQuery, SqliteConnection connection)
		{
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		internal void ExecuteNonQuery()
		{
			throw new NotImplementedException();
		}
	}
}