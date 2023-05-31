function solve(input){
    let lookingBook = input[0];
    let checkedBooks = 0;
    let index = 1;

    while(true){
        let currentBook = input[index];

        if(currentBook == lookingBook){
            console.log(`You checked ${checkedBooks} books and found it.`);
            break;
        }

        if(currentBook == 'No More Books'){
            console.log('The book you search is not here!');
            console.log(`You checked ${checkedBooks} books.`);
            break;
        }

        index++;
        checkedBooks++;
    }
}

// solve(['Troy','Stronger','Life Style','Troy']);