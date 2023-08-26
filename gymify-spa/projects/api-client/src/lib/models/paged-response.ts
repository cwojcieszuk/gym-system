export interface PagedResponse<T> {
  content: T[];
  totalRecords: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}
