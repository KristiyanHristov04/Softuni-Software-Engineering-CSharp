function deleteByEmail() {
    let emailToBeRemoved = document.getElementsByName('email')[0].value;
    let allTds = document.querySelectorAll('tbody tr td:nth-child(even)');
    let result = document.getElementById('result');
    for (const currentTd of allTds) {
        if (currentTd.textContent === emailToBeRemoved) {
            currentTd.parentElement.remove();
            result.textContent = 'Deleted.';
            break;
        } else {
            result.textContent = 'Not found.';
        }
    }
}