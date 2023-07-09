function solve(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice){
    let totalExpenses = 0;
    let brokenShieldCount = 0;
    for (let i = 1; i <= lostFights; i++) {
        if(i % 2 == 0){
            totalExpenses += helmetPrice;
        }

        if(i % 3 == 0){
            totalExpenses += swordPrice;
        }

        if(i % 2 == 0 && i % 3 == 0){
            totalExpenses += shieldPrice;
            brokenShieldCount++;
        }

        if(brokenShieldCount == 2){
            totalExpenses += armorPrice;
            brokenShieldCount = 0;
        }
    }
    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}

solve(7, 2, 3, 4, 5);
solve(23, 12.50, 21.50, 40, 200);