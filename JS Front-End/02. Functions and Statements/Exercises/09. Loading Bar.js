function loadingBar(bar) {
    if (bar == 100) {
        console.log('100% Complete!');
        return;
    }

    printLoadingBar();

    function printLoadingBar() {
        let percentageDone = bar / 10;
        let barVisualisation = `[${'%'.repeat(percentageDone).padEnd(10, '.')}]`
        console.log(`${bar}% ${barVisualisation}`);
        console.log(`Still loading...`);
    }
}

loadingBar(30);
loadingBar(50);
loadingBar(100);