window.addEventListener("load", solve);

function solve() {
    const addButton = document.getElementById('add-btn');
    const [expenseInput, amountInput, dateInput] = document.querySelectorAll('input');
    const previewList = document.getElementById('preview-list');
    const expensesList = document.getElementById('expenses-list');
    const deleteButton = document.getElementsByClassName('delete')[0];

    deleteButton.addEventListener('click', () => {
        location.reload();
    });
    
    addButton.addEventListener('click', (e) => {
        if (validateInputs()) {
            let li = document.createElement('li');
            li.classList.add('expense-item');
    
            let article = document.createElement('article');
    
            let expenseTypeP = document.createElement('p');
            expenseTypeP.textContent = `Type: ${expenseInput.value}`;
    
            let amountP = document.createElement('p');
            amountP.textContent = `Amount: ${amountInput.value}$`;
    
            let dateP = document.createElement('p');
            dateP.textContent = `Date: ${dateInput.value}`;
    
            let div = document.createElement('div');
            div.classList.add('buttons');
    
            let editButton = document.createElement('button');
            editButton.classList.add('btn', 'edit');
            editButton.textContent = 'edit';
            editButton.addEventListener('click', (e) => {
                let articleElement = e.currentTarget.parentElement.parentElement.children[0];
                let expense = articleElement.children[0].textContent.split(' ')[1];
                let amount = articleElement.children[1].textContent.split(' ')[1];
                amount = amount.substring(0, amount.length - 1);
                let date = articleElement.children[2].textContent.split(' ')[1];
                
                expenseInput.value = expense;
                amountInput.value = amount;
                dateInput.value = date;

                addButton.disabled = false;

                previewList.children[0].remove();
            });
    
            let okayButton = document.createElement('button');
            okayButton.classList.add('btn', 'ok');
            okayButton.textContent = 'ok';
            okayButton.addEventListener('click', (e) => {
                let liClone = e.currentTarget.parentElement.parentElement.cloneNode(true);
                e.currentTarget.parentElement.parentElement.remove();
                liClone.children[1].remove();
                expensesList.appendChild(liClone);
            });
    
            article.appendChild(expenseTypeP);
            article.appendChild(amountP);
            article.appendChild(dateP);
    
            div.appendChild(editButton);
            div.appendChild(okayButton);
    
            li.appendChild(article);
            li.appendChild(div);
    
            previewList.appendChild(li);
    
            e.currentTarget.disabled = true;
            clearInputs();
        }
    });
    
    function validateInputs() {
        if (expenseInput.value.length === 0 || amountInput.value.length === 0
            || dateInput.value.length === 0) {
            return false;
        }
    
        return true;
    }
    
    function clearInputs() {
        expenseInput.value = '';
        amountInput.value = '';
        dateInput.value = '';
    }
}

