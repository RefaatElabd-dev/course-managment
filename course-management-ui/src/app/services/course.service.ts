import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { APIResponse, PagedResponse } from "../models/api-response.model";
import { ICourseResponse, ICourseRequest } from "../models/course.model";
import { FilterBase } from "../models/filter-base.model";

@Injectable({ providedIn: 'root' })
export class CourseService {
  private baseUrl = 'http://localhost:5286/api/Course';

  constructor(private http: HttpClient) {}

  getAll(filter: FilterBase): Observable<APIResponse<PagedResponse<ICourseResponse>>> {
    return this.http.post<APIResponse<PagedResponse<ICourseResponse>>>(`${this.baseUrl}/filter`, filter);
  }

  get(id: number): Observable<APIResponse<ICourseResponse>> {
    return this.http.get<APIResponse<ICourseResponse>>(`${this.baseUrl}/${id}`);
  }

  create(course: ICourseRequest): Observable<APIResponse<ICourseResponse>> {
    return this.http.post<APIResponse<ICourseResponse>>(this.baseUrl, course);
  }

  update(id: number, course: ICourseRequest): Observable<APIResponse<ICourseResponse>> {
    return this.http.put<APIResponse<ICourseResponse>>(`${this.baseUrl}/${id}`, course);
  }

  delete(id: number): Observable<APIResponse<boolean>> {
    return this.http.delete<APIResponse<boolean>>(`${this.baseUrl}/${id}`);
  }
}
