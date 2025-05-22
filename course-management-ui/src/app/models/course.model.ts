export interface ICourseResponse {
  id: number;
  title: string;
  description: string;
  instructor: string;
  startDate: string;
  endDate: string;
  isCompleted: boolean;
}

export interface ICourseRequest {
  title: string;
  description: string;
  instructor: string;
  startDate: string;
  endDate: string;
  isCompleted: boolean;
}
