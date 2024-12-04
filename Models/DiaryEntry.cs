using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class DiaryEntry
	{
	 public long Id { get; set; }
	 public string? Title { get; set; }
	 public string? Content;

		public string? GetContent()
		{
			return Content;
		}

		public void SetContent(string? value)
		{
			Content = value;
		}

	 public string? Emotion { get; set; }
	 public DateTime Date { get; set; }
	 public bool IsPublic { get; set; }
	}
}
