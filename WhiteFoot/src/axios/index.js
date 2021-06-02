import axios from 'axios'

export default axios.create({
  baseURL: 'https://localhost:5001/api/'
})

// intercepter로 error handling 가능?