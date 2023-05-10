function neededHoursToReadABook(input){
    let bookPages = Number(input[0]);
    let pagesReadForOneHour = Number(input[1]);
    let numberOfDaysToReadTheBook = Number(input[2]);

    let totalNeededHours = bookPages / pagesReadForOneHour;
    let hoursNeededEveryDay = totalNeededHours / numberOfDaysToReadTheBook;
    console.log(hoursNeededEveryDay);
}

neededHoursToReadABook(["212", "20","2"]);
neededHoursToReadABook(["432", "15","4"]);