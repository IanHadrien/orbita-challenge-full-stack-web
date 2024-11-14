import axios from "axios"

const url = "http://localhost:5053/api"

export const api = axios.create({
  baseURL: url,
})

api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("@authToken")

    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }

    return config
  },

  (error) => {
    return Promise.reject(error)
  }
)