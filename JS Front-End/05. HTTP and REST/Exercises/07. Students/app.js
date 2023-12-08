function attachEvents() {
  const URL = 'http://localhost:3030/jsonstore/collections/students';
  const tbody = document.querySelector('#results tbody');
  const submitButton = document.getElementById('submit');
  const [firstNameInput, lastNameInput, facultyNumberInput, gradeInput] = document.querySelectorAll('input[type=text]');

  extractStudents();

  submitButton.addEventListener('click', (e) => {
    fetch(URL, {
      method: 'POST',
      body: JSON.stringify({
        firstName: firstNameInput.value,
        lastName: lastNameInput.value,
        facultyNumber: facultyNumberInput.value,
        grade: gradeInput.value,
      })
    })
    .then(firstNameInput.value = '', lastNameInput.value = '',
          facultyNumberInput.value = '', gradeInput.value = '')
    .then(extractStudents)
    .catch(error => console.log(error));
  });

  function extractStudents() {
    tbody.innerHTML = '';
    fetch(URL)
      .then(response => response.json())
      .then(data => {
        let students = Object.values(data);
        for (const student of students) {
          let firstName = student.firstName;
          let lastName = student.lastName;
          let facultyNumber = student.facultyNumber;
          let grade = Number(student.grade).toFixed(2);
          loadStudent(firstName, lastName, facultyNumber, grade);
        }
      })
      .catch(error => console.log(error));
  }

  function loadStudent(firstName, lastName, facultyNumber, grade) {
    let tr = document.createElement('tr');

    let firstNameTd = document.createElement('td');
    firstNameTd.textContent = firstName;

    let lastNameTd = document.createElement('td');
    lastNameTd.textContent = lastName;

    let facultyNumberTd = document.createElement('td');
    facultyNumberTd.textContent = facultyNumber;

    let gradeTd = document.createElement('td');
    gradeTd.textContent = grade;

    tr.appendChild(firstNameTd);
    tr.appendChild(lastNameTd);
    tr.appendChild(facultyNumberTd);
    tr.appendChild(gradeTd);

    tbody.appendChild(tr);
  }
}

attachEvents();