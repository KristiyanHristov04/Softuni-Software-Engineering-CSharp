async function solution() {
    const API_LOGIN = 'http://localhost:3030/users/login'
    const API_REGISTER = 'http://localhost:3030/users/register'
    const loginErrorMsg = document.querySelector('#login p')
    const registerErrorMsg = document.querySelector('#register p')

    const loginNav = document.querySelector('#guest')
    const logoutNavBtn = document.querySelector('#logout')
    const loginNavBtn = document.querySelector('#guest #login')

    const [loginEmail, loginPassword] = document.querySelectorAll('#login label input')
    const loginBtn = document.querySelector('#login button')

    const [registerEmail, registerPassword, registerRepeat] = document.querySelectorAll('#register label input')
    const registerBtn = document.querySelector('#register button')


    const userName = document.querySelector('span')

    let correctLogin = []


    loginErrorMsg.textContent = ''


    const loginDetails = (email, password) => {
        return {
            email, password
        }
    }


    const loginApiRequest = async (email, password) => {


        let data = await fetch(API_LOGIN, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(loginDetails(email, password))
        })
        if (data.status !== 200) {
            correctLogin = []
            const errorMsg = await data.json()
            loginErrorMsg.textContent = errorMsg.message
            return

        }
        data = await data.json()

        correctLogin.push(email)
        correctLogin.push(password)
        userName.textContent = data.email
        loginNav.style.display = 'none'

    }

    const loginBtnFunctionality = async () => {
        await loginApiRequest(loginEmail.value, loginPassword.value)
    }

    const registerApiRequest = async (registerEmail, registerPassword, registerRepeat) => {
        registerErrorMsg.textContent = ''


        let data = await fetch(API_REGISTER, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(loginDetails(registerEmail, registerPassword))
        })

        if (data.status !== 200) {
            const errorMsg = await data.json()
            registerErrorMsg.textContent = errorMsg.message
            return
        }

        console.log(data)
    }

    const registerBtnFunctionality = async () => {
        await registerApiRequest(registerEmail.value, registerPassword.value, registerRepeat.value)

    }

    const logoutNavBtnFunctionality = async () => {
        if (!correctLogin) {
            return
        }
        await fetch('http://localhost:3030/users/logout')
        correctLogin = []
        loginNav.style.display = 'inline-block'
        userName.textContent = 'guest'
    }


    const loginNavBtnFunctionality = async () => {
        // await loginApiRequest(...correctLogin)
        // console.log(loginNavBtn)
    }


    loginBtn.addEventListener('click', loginBtnFunctionality)
    registerBtn.addEventListener('click', registerBtnFunctionality)
    logoutNavBtn.addEventListener('click', logoutNavBtnFunctionality)
    loginNavBtn.addEventListener('click', loginNavBtnFunctionality)


}

solution();