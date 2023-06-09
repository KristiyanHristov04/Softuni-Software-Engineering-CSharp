function solve(input){
    let movieName = input[0];
    let totalSoldTickets = 0;
    let standardTicketsCounter = 0;
    let studentTicketsCounter = 0;
    let kidTicketsCounter = 0;
    let index = 1;
    while(movieName != 'Finish'){
        let currentMovieFreeSpace = Number(input[index]);
        let currentMovieSoldTickets = 0;
        let ticketType = input[index + 1];
        index++;
        while(ticketType != 'End'){
            if(ticketType == 'standard'){
                standardTicketsCounter++;
            }
            else if(ticketType == 'student'){
                studentTicketsCounter++;
            }
            else{
                kidTicketsCounter++;
            }
            currentMovieSoldTickets++;
            totalSoldTickets++;
            if(currentMovieSoldTickets == currentMovieFreeSpace){
                break;
            }
            index++;
            ticketType = input[index];
        }
        console.log(`${movieName} - ${((currentMovieSoldTickets / currentMovieFreeSpace) * 100).toFixed(2)}% full.`);
        index++;
        movieName = input[index];
        index++;
    }
    console.log(`Total tickets: ${totalSoldTickets}`);
    console.log(`${((studentTicketsCounter / totalSoldTickets) * 100).toFixed(2)}% student tickets.`);
    console.log(`${((standardTicketsCounter / totalSoldTickets) * 100).toFixed(2)}% standard tickets.`);
    console.log(`${((kidTicketsCounter / totalSoldTickets) * 100).toFixed(2)}% kids tickets.`);
}

// solve(["Taxi",
// "10",
// "standard",
// "kid",
// "student",
// "student",
// "standard",
// "standard",
// "End",
// "Scary Movie",
// "6",
// "student",
// "student",
// "student",
// "student",
// "student",
// "student",
// "Finish"]);