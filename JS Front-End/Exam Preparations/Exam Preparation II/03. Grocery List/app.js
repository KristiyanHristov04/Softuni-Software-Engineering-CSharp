function solve() {
    const productNameInput = document.getElementById('product');
    const countInput = document.getElementById('count');
    const priceInput = document.getElementById('price');
    const addProductButton = document.getElementById('add-product');
    const updateProductButton = document.getElementById('update-product');
    const loadProductsButton = document.getElementById('load-product');
    const tbody = document.querySelector('.tbl-content table #tbody');
    const URL = `http://localhost:3030/jsonstore/grocery`;
    let patchId = '';

    addProductButton.addEventListener('click', addProductHandler);
    loadProductsButton.addEventListener('click', loadProductsHandler);
    updateProductButton.addEventListener('click', event => {
        event.preventDefault();
        let objFetch = {
            product: productNameInput.value,
            count: countInput.value,
            price: priceInput.value
        };

        let httpRequest = {
            method: 'PATCH',
            body: JSON.stringify(objFetch)
        };

        fetch(`${URL}/${patchId}`, httpRequest)
            .then(() => loadProductsHandler())
            .catch(error => console.error(error));

        updateProductButton.disabled = true;
        clearInputs(productNameInput, countInput, priceInput);
        addProductButton.disabled = false;
    });

    function addProductHandler(event) {
        event.preventDefault();
        let newProductObject = {
            product: productNameInput.value,
            count: countInput.value,
            price: priceInput.value
        };

        let httpRequest = {
            method: 'POST',
            body: JSON.stringify(newProductObject)
        }

        fetch(URL, httpRequest)
            .then(() => loadProductsHandler())
            .catch(error => console.error());

        clearInputs(productNameInput, countInput, priceInput);
    }

    function loadProductsHandler(event) {
        if (event) {
            event.preventDefault();
        }
        tbody.textContent = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let allProducts = Object.values(data);
                console.log(allProducts);
                for (let index = 0; index < allProducts.length; index++) {
                    let tr = document.createElement('tr');
                    tr.id = allProducts[index]._id;
                    let tdName = document.createElement('td');
                    tdName.classList.add('name');
                    tdName.textContent = allProducts[index].product;
                    let tdCount = document.createElement('td');
                    tdCount.classList.add('count-product');
                    tdCount.textContent = allProducts[index].count;
                    let tdPrice = document.createElement('td');
                    tdPrice.classList.add('product-price');
                    tdPrice.textContent = allProducts[index].price;
                    let tdButton = document.createElement('td');
                    tdButton.classList.add('btn');
                    let updateButton = document.createElement('button');
                    updateButton.classList.add('update');
                    updateButton.textContent = 'Update';
                    updateButton.addEventListener('click', updateProductHandler);
                    let deleteButton = document.createElement('button');
                    deleteButton.classList.add('delete');
                    deleteButton.textContent = 'Delete';
                    deleteButton.addEventListener('click', deleteProductHandler);
                    tdButton.appendChild(updateButton);
                    tdButton.appendChild(deleteButton);
                    tr.appendChild(tdName);
                    tr.appendChild(tdCount);
                    tr.appendChild(tdPrice);
                    tr.appendChild(tdButton);
                    tbody.appendChild(tr);
                }
            })
            .catch(error => console.error(error));
    }

    function updateProductHandler(event) {
        addProductButton.disabled = true;
        updateProductButton.disabled = false;
        let tr = event.currentTarget.parentElement.parentElement;
        let trChildren = tr.children;
        let idToFetch = tr.id;
        patchId = idToFetch;
        productNameInput.value = trChildren[0].textContent;
        countInput.value = trChildren[1].textContent;
        priceInput.value = trChildren[2].textContent;
    }

    function deleteProductHandler(event) {
        let trToBeRemoved = event.currentTarget.parentElement.parentElement;
        let idToBeRemoved = trToBeRemoved.id;

        let httpRequest = {
            method: 'DELETE'
        };

        fetch(`${URL}/${idToBeRemoved}`, httpRequest)
            .then(() => loadProductsHandler())
            .catch(error => console.error(error));

        tbody.removeChild(trToBeRemoved);
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }
}

solve();