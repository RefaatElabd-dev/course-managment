export interface FilterBase {
  search?: string;
  sortBy?: string;
  sortDesc?: boolean;
  page: number;
  pageSize: number;
}
