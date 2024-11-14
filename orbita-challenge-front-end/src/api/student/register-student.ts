import { api } from "@/plugins/axios"

export interface StudentRegisterRequest {
  name: string;
  email: string;
  ra: string;
  cpf: string;
}

export async function registerStudentApi({
  name,
  cpf,
  email,
  ra
}: StudentRegisterRequest) {
  await api.post('/Students', { name, cpf, email, ra })
}