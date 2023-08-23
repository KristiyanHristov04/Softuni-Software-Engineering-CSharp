function solve(input) {
    let shoppingList = input.shift().split('!');
    while (true) {
        let currentCommand = input.shift().split(' ');
        if (currentCommand[0] === 'Urgent') {
            let itemToAdd = currentCommand[1];
            if (!shoppingList.includes(itemToAdd)) {
                shoppingList.unshift(itemToAdd);
            }
        } else if(currentCommand[0] === 'Unnecessary') {
            let itemToRemove = currentCommand[1];
            let itemToRemoveIndex = shoppingList.indexOf(itemToRemove);
            if (itemToRemoveIndex !== -1) {
                shoppingList.splice(itemToRemoveIndex, 1);
            }
        } else if (currentCommand[0] === 'Correct') {
            let oldItemName = currentCommand[1];
            let newItemName = currentCommand[2];
            for (let index = 0; index < shoppingList.length; index++) {
                if (shoppingList[index] === oldItemName) {
                    shoppingList[index] = newItemName;
                    break;
                }
            }
        } else if (currentCommand[0] === 'Rearrange'){
            let itemNameToRearrange = currentCommand[1];
            let itemIndex = shoppingList.indexOf(itemNameToRearrange);
            if (itemIndex !== -1) {
                shoppingList.splice(itemIndex, 1);
                shoppingList.push(itemNameToRearrange);
            }
        } else {
            console.log(shoppingList.join(', '));
            return;
        }
    }
}

// solve((["Tomatoes!Potatoes!Bread",
//     "Unnecessary Milk",
//     "Urgent Tomatoes",
//     "Go Shopping!"])
// );

solve((["Milk!Pepper!Salt!Water!Banana",
"Urgent Salt",
"Unnecessary Grapes",
"Correct Pepper Onion",
"Rearrange Grapes",
"Correct Tomatoes Potatoes",
"Go Shopping!"])
);