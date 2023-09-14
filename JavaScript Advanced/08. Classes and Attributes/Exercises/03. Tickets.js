function solve(ticketsInput, sortingCriterion) {
    class Ticket {
        constructor(destinationName, price, status) {
            this.destination = destinationName;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (let index = 0; index < ticketsInput.length; index++) {
        let [destination, price, status] = ticketsInput[index].split('|');
        price = Number(price);
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    let sortedTickets = [];

    if (sortingCriterion === 'destination') {
        sortedTickets = tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (sortingCriterion === 'status') {
        sortedTickets = tickets.sort((a, b) => a.status.localeCompare(b.status));
    } else {
        sortedTickets = tickets.sort((a, b) => a.price - b.price);
    }

    return sortedTickets;
}

// console.log(solve(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'destination'));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));
