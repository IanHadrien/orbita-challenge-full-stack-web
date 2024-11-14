import { api } from "@/plugins/axios"

export interface SignInRequest {
  email: string;
  password: string;
}

export async function signInApi({
  email,
  password
}: SignInRequest) {
  const response = await api.post('/Login', { email, password })

  return response.data
}