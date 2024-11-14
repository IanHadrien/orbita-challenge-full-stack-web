import { Student } from "@/_types/student";
import { api } from "@/plugins/axios";

interface GetStudentsApiResponse {
  students: Student[];
}

export async function getStudentsApi(): Promise<Student[]> {
  try {
    const response = await api.get<GetStudentsApiResponse>('/Students');
    return response.data.students;
  } catch (error) {
    console.error("Error fetching students:", error);
    throw new Error("Unable to fetch students");
  }
}