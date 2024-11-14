import { api } from "@/plugins/axios"

export interface StudentDeleteRequest {
  id: string;
}

export async function deleteStudentApi({
  id,
}: StudentDeleteRequest) {
  await api.delete(`/Students/${id}`)
}