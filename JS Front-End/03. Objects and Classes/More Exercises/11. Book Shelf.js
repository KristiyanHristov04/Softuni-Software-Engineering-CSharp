function solve(input) {
    let shelves = {};
    for (let i = 0; i < input.length; i++) {
        let line = input[i];
        let lineAsArrayElements = line.split(' -> ');
        if (lineAsArrayElements.length === 2) {
            let shelfId = Number(lineAsArrayElements[0]);
            let shelfGenre = lineAsArrayElements[1];
            if (!shelves.hasOwnProperty(shelfId)) {
                shelves[shelfId] = { genre: shelfGenre, books: []};
            }
        } else {
            let lineAsArrayElements = line.split(': ');
            let bookTitle = lineAsArrayElements[0];
            let [bookAuthor, bookGenre] = lineAsArrayElements[1].split(', ');
            let entries = Object.entries(shelves);
            for (let index = 0; index < entries.length; index++) {
                if (entries[index][1].genre === bookGenre) {
                    let bookObjectInfo = {title: bookTitle, author: bookAuthor};
                    entries[index][1].books.push(bookObjectInfo);
                }
            }
        }
    }

    let entries = Object.entries(shelves).sort((a, b) => b[1].books.length - a[1].books.length);
    for (let i = 0; i < entries.length; i++) {
        console.log(`${entries[i][0]} ${entries[i][1].genre}: ${entries[i][1].books.length}`);
        for (const iterator of entries[i][1].books) {
            console.log(`--> ${iterator.title}: ${iterator.author}`);
        }
    }
}

solve(['1 -> history',
       '1 -> action',
       'Death in Time: Criss Bell, mystery',
       '2 -> mystery',
       '3 -> sci-fi', 
       'Child of Silver: Bruce Rich, mystery',
       'Hurting Secrets: Dustin Bolt, action',
       'Future of Dawn: Aiden Rose, sci-fi',
       'Lions and Rats: Gabe Roads, history',
       '2 -> romance',
       'Effect of the Void: Shay B, romance',
       'Losing Dreams: Gail Starr, sci-fi',
       'Name of Earth: Jo Bell, sci-fi',
       'Pilots of Stone: Brook Jay, history']
);