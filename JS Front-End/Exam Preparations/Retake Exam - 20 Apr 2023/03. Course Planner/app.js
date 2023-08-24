function solve() {
    const courseTitleInput = document.getElementById('course-name');
    const courseTypeInput = document.getElementById('course-type');
    const courseDescriptionTextarea = document.getElementById('description');
    const courseTeacherNameInput = document.getElementById('teacher-name');
    const addCourseButton = document.getElementById('add-course');
    const editCourseButton = document.getElementById('edit-course');
    const coursesList = document.getElementById('list');
    const loadCoursesButton = document.getElementById('load-course');
    const URL = 'http://localhost:3030/jsonstore/tasks';
    let putId = '';

    addCourseButton.addEventListener('click', addCourseHandler);
    editCourseButton.addEventListener('click', editCoursePhase02Handler);
    loadCoursesButton.addEventListener('click', loadCoursesHandler);

    function editCoursePhase02Handler(event) {
        event.preventDefault();
        let putObject = {
            title: courseTitleInput.value,
            type: courseTypeInput.value,
            description: courseDescriptionTextarea.value,
            teacher: courseTeacherNameInput.value,
            _id: putId
        }

        let httpRequest = {
            method: 'PUT',
            body: JSON.stringify(putObject)
        };

        fetch(`${URL}/${putId}`, httpRequest)
            .then(() => loadCoursesHandler())
            .catch(error => console.error(error));

        editCourseButton.disabled = true;
        addCourseButton.disabled = false;
        clearInputs(courseTitleInput, courseTypeInput, courseDescriptionTextarea, courseTeacherNameInput);
    }

    function addCourseHandler(event) {
        event.preventDefault();
        if (checkIfInputsAreValid(courseTitleInput, courseTypeInput, courseDescriptionTextarea, courseTeacherNameInput)) {
            let newCourseObject = {
                title: courseTitleInput.value,
                type: courseTypeInput.value,
                description: courseDescriptionTextarea.value,
                teacher: courseTeacherNameInput.value
            };

            let httpRequest = {
                method: 'POST',
                body: JSON.stringify(newCourseObject)
            };

            fetch(URL, httpRequest)
                .then(() => loadCoursesHandler())
                .catch(error => console.error(error));

            clearInputs(courseTitleInput, courseTypeInput, courseDescriptionTextarea, courseTeacherNameInput);
        }
    }

    function loadCoursesHandler() {
        coursesList.textContent = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let coursesInfo = Object.values(data);
                for (let index = 0; index < coursesInfo.length; index++) {
                    let courseTitle = coursesInfo[index].title;
                    let courseType = coursesInfo[index].type;
                    let courseDescription = coursesInfo[index].description;
                    let courseTeacher = coursesInfo[index].teacher;
                    let courseId = coursesInfo[index]._id;

                    let divContainer = document.createElement('div');
                    divContainer.classList.add('container');
                    divContainer.id = courseId;
                    let h2 = document.createElement('h2');
                    h2.textContent = courseTitle;
                    let h3First = document.createElement('h3');
                    h3First.textContent = courseTeacher;
                    let h3Second = document.createElement('h3');
                    h3Second.textContent = courseType;
                    let h4 = document.createElement('h4');
                    h4.textContent = courseDescription;
                    let editButton = document.createElement('button');
                    editButton.classList.add('edit-btn');
                    editButton.textContent = 'Edit Course';
                    editButton.addEventListener('click', editCoursePhase01Handler);
                    let finishButton = document.createElement('button');
                    finishButton.classList.add('finish-btn');
                    finishButton.textContent = 'Finish Course';
                    finishButton.addEventListener('click', finishCourseHandler);
                    divContainer.appendChild(h2);
                    divContainer.appendChild(h3First);
                    divContainer.appendChild(h3Second);
                    divContainer.appendChild(h4);
                    divContainer.appendChild(editButton);
                    divContainer.appendChild(finishButton);
                    coursesList.appendChild(divContainer);
                }
            })
            .catch(error => console.error(error));
    }

    function finishCourseHandler(event) {
        let divParent = event.currentTarget.parentElement;
        let idToDelete = divParent.id;

        let httpRequest = {
            method: 'DELETE'
        }

        fetch(`${URL}/${idToDelete}`, httpRequest)
            .then(() => loadCoursesHandler())
            .catch(error => console.error(error));
    }

    function editCoursePhase01Handler(event) {
        let containerParent = event.currentTarget.parentElement;
        putId = containerParent.id;
        let containerChildren = Array.from(containerParent.children);
        let title = containerChildren[0].textContent;
        let teacher = containerChildren[1].textContent;
        let type = containerChildren[2].textContent;
        let description = containerChildren[3].textContent;
        coursesList.removeChild(containerParent);

        courseTitleInput.value = title;
        courseTypeInput.value = type;
        courseDescriptionTextarea.value = description;
        courseTeacherNameInput.value = teacher;

        addCourseButton.disabled = true;
        editCourseButton.disabled = false;
    }

    function clearInputs(...inputs) {
        inputs.map(input => input.value = '');
    }

    function checkIfInputsAreValid(...inputs) {
        // if (inputs[1].value !== 'Long' && inputs[1].value !== 'Medium' && inputs[1].value !== 'Short') {
        //     return false;
        // }

        // for (let index = 0; index < inputs.length; index++) {
        //     if (inputs[index].value === '') {
        //         return false;
        //     }
        // }

        return true;
    }
}

solve();