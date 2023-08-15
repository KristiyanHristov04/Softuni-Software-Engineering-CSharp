function generateReport() {
    const textarea = document.getElementById('output');
    let report = [];
    let obj = {};
    let allThsForObject = [];
    let allInputs = document.querySelectorAll('input[type="checkbox"]');
    let allThs = [];
    for (const input of allInputs) {
        allThsForObject.push(input.parentElement.textContent.toLowerCase().trim());
        if (input.checked === true) {
            allThs.push(input.parentElement.textContent.toLowerCase().trim());
        }
    }

    for (let index = 0; index < allThsForObject.length; index++) {
        obj[index] = allThsForObject[index];
    }

    let thsAsIndexes = convertThsToIndexes();

    let allTrs = Array.from(document.querySelectorAll('table tbody tr'));
    for (let currentTrIndex = 0; currentTrIndex < allTrs.length; currentTrIndex++) {
        let allTds = Array.from(allTrs[currentTrIndex].children);
        let newObject = {};
        for (let currentTdIndex = 0; currentTdIndex < allTds.length; currentTdIndex++) {
            if (thsAsIndexes.includes(currentTdIndex)) {
                let name = obj[currentTdIndex];
                newObject[name] = allTds[currentTdIndex].textContent;
            }
        }
        report.push(newObject);
    }

    let reportAsJSON = JSON.stringify(report, null, 2);
    textarea.value = reportAsJSON;
    
    function convertThsToIndexes() {
        let array = [];
        
        for (let index = 0; index < allThsForObject.length; index++) {
            for (let j = 0; j < allThs.length; j++) {
                if (allThs[j] === allThsForObject[index]) {
                    array.push(index);
                }
            }
        }
        return array;
    }
}