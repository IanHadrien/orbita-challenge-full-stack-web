import { Student } from "@/_types/student";
import { api } from "@/plugins/axios";

interface GetStudentsApiResponse {
  students: Student[];
}

export async function getStudentsApi(search?: string): Promise<Student[]> {
  const response = await api.get<GetStudentsApiResponse>(`/Students?search=${search ?? ''}`);
  
  return response.data.students;
}