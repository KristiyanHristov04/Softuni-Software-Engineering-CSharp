function sumTable() {
    const trs = document.querySelectorAll('tr');
    let trsArray = Array.from(trs);
    trsArray.shift();
    trsArray.pop();
    let totalSum = 0;
    for (const tr of trsArray) {
        let currentTrChildren = tr.children;
        let currentTrChildrenAsArray = Array.from(currentTrChildren);
        totalSum += Number(currentTrChildrenAsArray[1].textContent);
    }
    let tdResult = document.getElementById('sum');
    tdResult.textContent = totalSum;
}