import { api } from "@/plugins/axios"

export interface SignUpRequest {
  email: string;
  password: string;
}

export async function signUpApi({
  email,
  password
}: SignUpRequest) {
  const response = await api.post('/User', { email, password })

  return response.data
}