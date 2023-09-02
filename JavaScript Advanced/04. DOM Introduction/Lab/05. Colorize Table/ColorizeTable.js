function colorize() {
    const allEvenTrs = document.querySelectorAll('tr:nth-child(even)');
    for (const tr of allEvenTrs) {
        tr.style.backgroundColor = 'teal';
    }
}