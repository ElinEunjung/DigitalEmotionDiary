using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	internal class User
	{
		private long Id {  get; set; }
		private string? UserName { get; set; }
		private string? Emaail { get; set; }
		private string? Password { get; set; }
	}
}
