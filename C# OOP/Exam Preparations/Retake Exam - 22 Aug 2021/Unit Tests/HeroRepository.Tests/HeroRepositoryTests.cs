using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Validate_Hero_Constructor()
    {
        Hero hero = new Hero("Ivan", 15);
        Assert.That(hero.Name == "Ivan");
        Assert.That(hero.Level == 15);
    }

    [Test]
    public void Validate_Hero_Repository_Constructor()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("Ivan", 15));
        Assert.That(heroRepository.Heroes.Count == 1);
    }

    [Test]
    public void Validate_Create_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.That(heroRepository.Create(new Hero("Ivan", 15)) == $"Successfully added hero Ivan with level 15");
    }

    [Test]
    public void Method_Create_Throws_Exception_When_Hero_Is_Null()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(null);
        });
    }

    [Test]
    public void Method_Create_Throws_Exception_When_Hero_Already_Exists()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 15);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void Validate_Remove_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("Ivan", 15));
        Assert.That(heroRepository.Remove("Ivan") == true);
    }

    [Test]
    public void Method_Remove_Throws_Exception_When_Name_Is_Null()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(null);
        });
    }

    [Test]
    public void Validate_Get_Hero_With_Highest_Level_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero01 = new Hero("Ivan", 15);
        Hero hero02 = new Hero("George", 100);
        heroRepository.Create(hero01);
        heroRepository.Create(hero02);
        Assert.That(heroRepository.GetHeroWithHighestLevel() == hero02);
    }

    [Test]
    public void Validate_Get_Hero_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero01 = new Hero("Ivan", 15);
        Hero hero02 = new Hero("George", 100);
        heroRepository.Create(hero01);
        heroRepository.Create(hero02);
        Assert.That(heroRepository.GetHero("George") == hero02);
    }
}