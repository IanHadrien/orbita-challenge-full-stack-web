import { Student } from "@/_types/student";
import { api } from "@/plugins/axios";

interface GetStudentsApiResponse {
  students: Student[];
}

export async function getStudentsApi(): Promise<Student[]> {
  const response = await api.get<GetStudentsApiResponse>('/Students');
  
  return response.data.students;
}