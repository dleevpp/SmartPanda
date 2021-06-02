import axios from '../axios'
const jwt = require('jsonwebtoken')

const auth = {
  loggedIn: () => {
    const accessToken = localStorage.getItem('accessToken')
    try {
      jwt.verify(accessToken, '1234567890123456789', {
        algorithms: ['HS256'],
        audience: 'https://mywebapi.com',
        issuer: 'https://mywebapi.com',
      })
      console.log('success')
      return true
    }
    catch (err) {
      console.log(err.name)
      if (err.name === 'TokenExpiredError') {
        console.log('sTokenExpiredError')
        const refreshToken = localStorage.getItem('refreshToken')
        axios.post('Account/refresh-token', refreshToken)
          .then(res => {
            console.log(res)
            localStorage.setItem('refreshToken', res.data.refreshToken)
            return true
          })
          .catch(e => {
            console.log(e)
            return false
          })
      }
      console.log(err.message)
      return false
    }
  }
}

export default auth;