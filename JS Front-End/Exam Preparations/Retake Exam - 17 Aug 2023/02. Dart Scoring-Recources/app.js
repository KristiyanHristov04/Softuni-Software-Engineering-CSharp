window.addEventListener("load", solve);

function solve() {
  const addButton = document.getElementById('add-btn');
  const clearButton = document.querySelector('.btn.clear');
  const sureList = document.getElementById('sure-list');
  const scoreboardList = document.getElementById('scoreboard-list');
  const playerInput = document.getElementById('player');
  const scoreInput = document.getElementById('score');
  const roundInput = document.getElementById('round');

  addButton.addEventListener('click', (e) => {
    if (validateInputs()) {
      e.currentTarget.disabled = true;

      let li = document.createElement('li');
      li.classList.add('dart-item');
  
      let article = document.createElement('article');
  
      let nameParagraph = document.createElement('p');
      nameParagraph.textContent = playerInput.value;
  
      let scoreParagraph = document.createElement('p');
      scoreParagraph.textContent = `Score: ${Number(scoreInput.value)}`;
  
      let roundParagraph = document.createElement('p');
      roundParagraph.textContent = `Round: ${Number(roundInput.value)}`;
  
      let editButton = document.createElement('button');
      editButton.textContent = 'edit';
      editButton.classList.add('btn', 'edit');
      editButton.addEventListener('click', (e) => {
        let name = e.currentTarget.parentElement.children[0].children[0].textContent;
        let score = Number(e.currentTarget.parentElement.children[0].children[1].textContent.split(' ')[1]);
        let round = Number(e.currentTarget.parentElement.children[0].children[2].textContent.split(' ')[1]);
        addButton.disabled = false;
        playerInput.value = name;
        scoreInput.value = score;
        roundInput.value = round;
        e.currentTarget.parentElement.remove();
      });
  
      let okayButton = document.createElement('button');
      okayButton.textContent = 'ok';
      okayButton.classList.add('btn', 'ok');
      okayButton.addEventListener('click', (e) => {
        let liClone = sureList.children[0].cloneNode(1);

        liClone.children[1].remove();
        liClone.children[1].remove();
        
        addButton.disabled = false;

        e.currentTarget.parentElement.remove();
        scoreboardList.appendChild(liClone);
      });
  
      article.appendChild(nameParagraph);
      article.appendChild(scoreParagraph);
      article.appendChild(roundParagraph);
  
      li.appendChild(article);
      li.appendChild(editButton);
      li.appendChild(okayButton);
  
      sureList.appendChild(li);
  
      clearInputs();
    }
  });

  clearButton.addEventListener('click', () => {
    location.reload();
  });

  function clearInputs() {
    const inputs = document.querySelectorAll('input');

    for (const input of inputs) {
      input.value = '';
    }
  }

  function validateInputs() {
    const inputs = document.querySelectorAll('input');

    for (const input of inputs) {
      if (input.value.length === 0) {
        return false;
      }
    }
    return true;
  }
}
