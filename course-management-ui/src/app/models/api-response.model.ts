export interface APIResponse<T> {
  success: boolean;
  message?: string;
  data?: T;
}

export interface PagedResponse<T> {
  items: T[];
  totalCount: number;
}
