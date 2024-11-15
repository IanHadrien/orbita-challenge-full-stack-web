import axios from "axios"

const url = "http://localhost:5053/api"

export const api = axios.create({
  baseURL: url,
})

api.interceptors.request.use(
  (config) => {
    const storedData = localStorage.getItem("@authData");

    if (storedData) {
      const parsedData = JSON.parse(storedData)

      if (parsedData.token) {
        config.headers.Authorization = `Bearer ${parsedData.token}`
      }
    }

    return config
  },

  (error) => {
    return Promise.reject(error)
  }
)

api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      localStorage.removeItem("@authData");

      window.location.href = "/sign-in";
    }

    return Promise.reject(error);
  }
);