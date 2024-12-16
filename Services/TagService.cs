using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class TagService
	{
		private readonly TagRepository _tagRepository;


		public TagService(TagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		public void CreateTag(long id, string name)
		{
			var tag = new Tag
			{ 
				Id = id, 
				Name = name 
			};

			if (string.IsNullOrEmpty(tag.Name))
			{
				throw new ArgumentException("Tag name cannot be empty.");
			}

			_tagRepository.CreateTag(tag);
			_tagRepository.SaveChanges();
		}

		public void UpdateTag(Tag tag)
		{
			_tagRepository.UpdateTag(tag);
			_tagRepository.SaveChanges();
		}

		public void DeleteTag(Tag tag)
		{
			_tagRepository.DeleteTag(tag);
			_tagRepository.SaveChanges();
		}

		public List<EntryTag> GetTagsByDiaryEntryId(long diaryEntryId)
		{
			return _tagRepository.GetTagsByDiaryEntryId(diaryEntryId);
		}

	}

}
