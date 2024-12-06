using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Emotion
	{
		public Emotion() { }
		public EmotionType CurrentEmotion { get; set; }
		public Emotion(EmotionType emotion)
		{
			this.CurrentEmotion = emotion;
		}

		public static Dictionary<EmotionType, string> EmotionColors => new()
		{
			{ EmotionType.Happy, "Yellow" },
			{ EmotionType.Energized, "Orange" },
			{ EmotionType.Tired, "Beige" },
			{ EmotionType.Anxious, "Brown" },
			{ EmotionType.Stressed, "Light Red" },
			{ EmotionType.Sad, "Grey/Black" },
			{ EmotionType.Annoyed, "Red" },
			{ EmotionType.Neutral, "White" }
		};

		public string BackgroundColor => EmotionColors.ContainsKey(CurrentEmotion)
					? EmotionColors[CurrentEmotion]
					: "Unknown";

	}
}