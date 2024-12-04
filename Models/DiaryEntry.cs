using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class DiaryEntry
	{
	 private long Id { get; set; }
	 private string? Title { get; set; }
	 private string? content;

		private string? GetContent()
		{
			return content;
		}

		private void SetContent(string? value)
		{
			content = value;
		}

	 private string? Emotion { get; set; }
	 private DateTime Date { get; set; }
	 private bool IsPublic { get; set; }
	}
}
