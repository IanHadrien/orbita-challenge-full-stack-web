import { api } from "@/plugins/axios"

export interface StudentUpdateRequest {
  id: string;
  name: string;
  email: string;
}

export async function updateStudentApi({
  id,
  name,
  email,
}: StudentUpdateRequest) {
  await api.put(`/Students/${id}`, { name, email })
}