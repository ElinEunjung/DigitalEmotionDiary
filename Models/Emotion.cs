using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Emotion(EmotionType emotion)
	{
		public EmotionType CurrentEmotion { get; set; } = emotion;

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

		public string BackgroundColor {
			get
				{
					return EmotionColors[CurrentEmotion];
				}
		}

		//public void DisplayEmotion()
		//{
		//	Console.WriteLine($"Current Emotion: {CurrentEmotion}, Background Color: {BackgroundColor}")
		//}
	}
}