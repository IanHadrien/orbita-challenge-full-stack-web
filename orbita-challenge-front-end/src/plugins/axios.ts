import axios from "axios"

const tokenTest = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InRlc3RlQGV4YW1wbGUuY29tIiwibmJmIjoxNzMxNTQzNDA0LCJleHAiOjE3MzE1NTQyMDQsImlhdCI6MTczMTU0MzQwNH0.XIpzEHrhj-6SG0odmZAZdhLrqcTe_7sc1Xwur_DyZIw"
const url = "http://localhost:5053/api"

export const api = axios.create({
  // baseURL: env.VITE_API_URL,
  baseURL: url,
  headers: {
    // Authorization: `Bearer ${localStorage.getItem('access-token')}` 
    Authorization: `Bearer ${tokenTest}` 
  },
})