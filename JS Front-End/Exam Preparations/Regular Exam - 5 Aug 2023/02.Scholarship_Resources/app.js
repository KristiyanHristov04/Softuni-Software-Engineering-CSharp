window.addEventListener("load", solve);

function solve() {
  const nextButton = document.getElementById('next-btn');
  const [studentInput, universityInput, scoreInput] = document.querySelectorAll('input');
  const previewList = document.getElementById('preview-list');
  const candidatesList = document.getElementById('candidates-list');

  nextButton.addEventListener('click', addToPreviewList);

  function addToPreviewList(e) {
    if (validateInputs()) {
      e.currentTarget.disabled = true;
      let li = document.createElement('li');
      li.classList.add('application');

      let article = document.createElement('article');

      let studentNameh4 = document.createElement('h4');
      studentNameh4.textContent = studentInput.value;

      let universityNameP = document.createElement('p');
      universityNameP.textContent = `University: ${universityInput.value}`;

      let scoreP = document.createElement('p');
      scoreP.textContent = `Score: ${scoreInput.value}`;

      let editButton = document.createElement('button');
      editButton.classList.add('action-btn', 'edit');
      editButton.textContent = 'edit';
      editButton.addEventListener('click', (e) => {
        let article = e.currentTarget.parentElement.children[0];
        let name = article.children[0].textContent;
        let university = article.children[1].textContent.split(' ')[1];
        let score = article.children[2].textContent.split(' ')[1];
        studentInput.value = name;
        universityInput.value = university;
        scoreInput.value = score;

        e.currentTarget.parentElement.remove();
        nextButton.disabled = false;
      });

      let applyButton = document.createElement('button');
      applyButton.classList.add('action-btn', 'apply');
      applyButton.textContent = 'apply';
      applyButton.addEventListener('click', (e) => {
        let clone = e.currentTarget.parentElement.cloneNode(true);
        clone.children[1].remove();
        clone.children[1].remove();
        e.currentTarget.parentElement.remove();
        candidatesList.appendChild(clone);
        nextButton.disabled = false;
      });

      article.appendChild(studentNameh4);
      article.appendChild(universityNameP);
      article.appendChild(scoreP);

      li.appendChild(article);
      li.appendChild(editButton);
      li.appendChild(applyButton);

      previewList.appendChild(li);

      clearInputs();
    }
  }

  function clearInputs() {
    studentInput.value = '';
    universityInput.value = '';
    scoreInput.value = '';
  }

  function validateInputs() {
    if (studentInput.value.length === 0 ||
      universityInput.value.length === 0 ||
      scoreInput.value.length === 0) {
      return false;
    }
    return true;
  }
}
