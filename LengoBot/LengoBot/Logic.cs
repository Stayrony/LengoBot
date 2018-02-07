using System;
using System.Collections.Generic;
namespace LengoBot
{
	public interface ILevelManager
	{
		IEnumerable<Level> GetLevelCollection();
	}

	public interface IPhraseManager
	{
		PhraseText GetPhraseText(int userId);
		bool AddPhraseTextToUserVocabulary(int userId, int phraseId);
		bool AddTaskToScheduler(int userId, int taskInfoId, DateTime time);
		bool UpdateTaskInScheduler(int schedulerId, DateTime time);
	}

	public interface ITranslationTaskManager
	{
		TranslationTask GetTask(int taskInfoId);
		TranslationResult CheckTranslation(UserTranslation userTranslation);
		IEnumerable<TranslationVariation> GetTranslationVariationCollection(int phraseId, int translationLanguageId);
	}

	public interface IUserSettingsManager
	{
		void SetTranslationLanguage(int userId, int languageId);
		void SetLevel(int userId, int levelId);
		//When should I notify you that new words are available for learning?
		void SetNotification(int userId, DateTime fromDateTime, DateTime toDateTime);
	}

	public interface IUserManager
	{
		int RegisterUser(string nickName);
	}

	public interface ILanguageManager
	{
		IEnumerable<Language> GetLanguageCollection();
		Language AddLanguage(string name, string slug);
	}

	public class UserTranslation
	{
		public int TaskInfoId { get; set; }
		public int TranslationPhraseId { get; set; }
	}

	public class TranslationTask
	{
		public string PhraseTest { get; set; }
		public IEnumerable<TranslationVariation> TranslationVariationCollection { get; set; }
		public int TaskInfoId { get; set; }
	}

	public class TranslationResult
	{

	}

	public class TranslationVariation
	{
		public int PhraseId { get; set; }
		public string PhraseText { get; set; }
	}

	public class PhraseText
	{
		public string PhraseId { get; set; }
		public string Description { get; set; }
		public string Text { get; set; }
		public string SoundBody { get; set; }
		public string ImageBody { get; set; }
	}

	// ENTITY

	public class Language
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
	}

	public class Level
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class User
	{
		public int Id { get; set; }
		public int LevelId { get; set; }
		public int LanguageId { get; set; }
		public string NickName { get; set; }
	}

	public class Phrase
	{
		public int Id { get; set; }
		public int LanguageId { get; set; }
		public string Description { get; set; }
		public string PhraseText { get; set; }
		public string SoundBody { get; set; }
		public string ImageBody { get; set; }
	}

	public class Notification
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public DateTime FromDateTime { get; set; }
		public DateTime ToDateTime { get; set; }
	}

	public class TaskInfo
	{
		public int Id { get; set; }
		public int PhraseId { get; set; }
		public int TranslationLanguageId { get; set; }
	}

	public class LevelPhrase
	{
		public int Id { get; set; }
		public int PhraseId { get; set; }
		public int LevelId { get; set; }
	}

	public class Translation
	{
		public int Id { get; set; }
		public int PhraseId { get; set; }
		public int TranslationLanguageId { get; set; }
		public string TranslationText { get; set; }
	}

	public class Scheduler
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int TaskInfoId { get; set; }
		public DateTime ExecuteInDateTime { get; set; }
	}

	public class UserVocabulary
	{
		public int UserId { get; set; }
		public int PhraseId { get; set; }
	}
}
