function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

    function onClick() {
        let searchElement = document.getElementById('searchField');
        let rowElements = Array.from(document.querySelectorAll('.container tbody tr'));
        let searchText = searchElement.value;

        rowElements.forEach(row => {
            row.className = '';
        });

        let filteredRows = rowElements.filter(row => {
            let values = Array.from(row.children);

            if (values.some(td => td.textContent.includes(searchText))) {
                row.className = 'select';
            }
        });

        searchElement.value = '';
    }
}