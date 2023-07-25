function solve(input) {
    class Hero {
        constructor(name, level, items) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
    }

    let heroes = [];

    for (let index = 0; index < input.length; index++) {
        let [heroName, heroLevel, heroItems] = input[index].split(' / ');
        let newHero = new Hero(heroName, Number(heroLevel), heroItems);
        heroes.push(newHero);
    }

    heroes.sort((a, b) => a.level - b.level);


    for (const hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`)
    }
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);