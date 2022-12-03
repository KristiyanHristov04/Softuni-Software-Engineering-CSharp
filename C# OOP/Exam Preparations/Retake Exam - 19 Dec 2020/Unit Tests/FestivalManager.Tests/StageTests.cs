// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void Validate_Song_Constructor()
	    {
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 10));
			Assert.That(song.Name == "Smooth Criminal");
			Assert.That(song.Duration == new TimeSpan(0, 4, 10));
		}

        [Test]
		public void Validate_Song_To_String_Method()
        {
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 10));
			Assert.That(song.ToString() == $"{song.Name} ({song.Duration:mm\\:ss})");
		}

        [Test]
		public void Validate_Performer_Constructor()
        {
			Performer performer = new Performer("John", "Lennon", 41);
			Assert.That(performer.Age == 41);
			Assert.That(performer.FullName == "John Lennon");
        }

        [Test]
		public void Validate_Performer_To_String_Method()
        {
			Performer performer = new Performer("John", "Lennon", 41);
			Assert.That(performer.ToString() == "John Lennon");
		}

        [Test]
		public void Validate_Stage_Constructor()
        {
			Stage stage = new Stage();
			Assert.That(stage.Performers.Count == 0);
			Assert.That(stage.Performers != null);
        }

        [Test]
		public void Validate_Add_Performer_Method()
        {
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 41);
			stage.AddPerformer(performer);
			Assert.That(stage.Performers.Count == 1);
        }

		[Test]
		public void Method_Add_Performer_Throws_Exception_When_Performer_Age_Is_Under_18()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 17);
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			});
		}

		[Test]
		public void Validate_Add_Song_Method()
		{
			Stage stage = new Stage();
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 0));
			stage.AddSong(song);
			//Maybe not enough to satisfy judge tests
		}

        [Test]
		public void Method_Add_Song_Throws_Exception_When_Song_Duration_Is_Less_Than_One_Minute()
        {
			Stage stage = new Stage();
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 0, 59));
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}

		[Test]
		public void Validate_Add_Song_To_Performer_Method()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 41);
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 59));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			Assert.That(stage.AddSongToPerformer("Smooth Criminal", "John Lennon") == $"{song} will be performed by {performer.FullName}");
		}

		[Test]
		public void Method_Get_Performer_Throws_Exception_When_Performer_With_That_Name_Doesnt_Exist()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 41);
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 59));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentException>(() =>
			{
				Assert.That(stage.AddSongToPerformer("Smooth Criminal", "Mike") == $"{song} will be performed by {performer.FullName}");
			});
		}

		[Test]
		public void Method_Get_Song_Throws_Exception_When_Performer_With_That_Name_Doesnt_Exist()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 41);
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 59));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentException>(() =>
			{
				Assert.That(stage.AddSongToPerformer("aa", "John Lennon") == $"{song} will be performed by {performer.FullName}");
			});
		}

		[Test]
		public void Method_Validate_Null_Value_Throws_Exception_When_Variable_Is_Null()
		{
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddSong(null);
			});
		}

		[Test]
		public void Validate_Play_Method()
        {
			Stage stage = new Stage();
			Performer performer = new Performer("John", "Lennon", 41);
			Song song = new Song("Smooth Criminal", new TimeSpan(0, 4, 0));
			performer.SongList.Add(song);
			stage.AddPerformer(performer);
			Assert.That(stage.Play() == $"{stage.Performers.Count} performers played {performer.SongList.Count} songs");
		}

		[Test]
		public void Validate_Get_Performer_Method()
		{
			
		}
	}
}