function solve() {
  const API_URL = 'http://localhost:3030/data/furniture' // get
  const API_REGISTER_USER = 'http://localhost:3030/users/register' // post
  const API_LOGIN_USER = 'http://localhost:3030/users/login' // login

  const [eMail, password, repeat] = document.querySelectorAll('form[action="/register"] label')
  const [register, login] = document.querySelectorAll('#exercise button')

  const logingAuto = () => {

  }

  const registerFunctionality = () => {
      console.log('register')
  }

  const loginFunctionality = () => {
      event.preventDefault()
      console.log('login')
  }

  register.addEventListener('click', registerFunctionality)
  login.addEventListener('click', loginFunctionality)



}