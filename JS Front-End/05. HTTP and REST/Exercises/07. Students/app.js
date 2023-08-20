async function attachEvents() {
  const studentsApi = 'http://localhost:3030/jsonstore/collections/students'
  const inputFields = Array.from(document.querySelectorAll('input[type="text"]'))
  const submitBtn = document.querySelector('#submit')
  const tbody = document.querySelector('tbody')

  const checkCorrectInputs = () => {
      for (const item of inputFields) {
          if (!item.value.trim()) {
              return false
          }
      }
      return true
  }

  const clearInputFields = () => {
      inputFields.forEach(x => x.value = '');
  }

  const createStudent = () => {
      return {
          firstName: inputFields[0].value,
          lastName: inputFields[1].value,
          facultyNumber: inputFields[2].value,
          grade: inputFields[3].value
      }
  }

  const saveStudentToDB = async () => {
      try {
          await fetch(studentsApi, {
              method: 'POST', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(createStudent())
          })
      } catch (error) {

      }

  }

  const createElementWithTextContent = (tag, textContent) => {
      const e = document.createElement(tag)
      e.textContent = textContent
      return e
  }

  const loadStudents = async () => {
      tbody.innerHTML = ''
      try {
          let data = await fetch(studentsApi)
          data = await data.json()
          for (const key in data) {
              const td = document.createElement('tr')
              td.appendChild(createElementWithTextContent('td', `${data[key].firstName}`))
              td.appendChild(createElementWithTextContent('td', `${data[key].lastName}`))
              td.appendChild(createElementWithTextContent('td', `${data[key].facultyNumber}`))
              td.appendChild(createElementWithTextContent('td', `${data[key].grade}`))
              tbody.appendChild(td)
          }

      } catch (error) {
      }
  }

  await loadStudents()

  submitBtn.addEventListener('click', async () => {
      if (!checkCorrectInputs()) {
          return
      }
      await saveStudentToDB()
      clearInputFields()
      await loadStudents()
  })

}

attachEvents();