using DigitalEmotionDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.UI
{
	public class DiaryEntryUI
	{
		private readonly DiaryEntryService _diaryEntryService;

		public DiaryEntryUI(DiaryEntryService diaryEntryService)
		{
			_diaryEntryService = diaryEntryService;
		}

		
		public void WriteDiaryEntry()
		{
			// WriteDiaryEntry logic
		}

		public void DeleteDiaryEntry()
		{
			// DeleteDiaryEntry logic
		}

		public void UpdateDiaryEntry()
		{
			// UpdateDiaryEntry logic
		}
	}
}
