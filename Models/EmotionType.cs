using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class EmotionType
	{
		public int Id { get; set; }
		public required string Name { get; set; }

		public ICollection<Emotion> Emotions { get; set; } = [];
	}
}
