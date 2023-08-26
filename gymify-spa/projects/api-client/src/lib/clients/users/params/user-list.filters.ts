import { PagedRequest } from '../../../models/paged-request';

export interface UserListFilters extends PagedRequest {
  name?: string;
  role?: string;
  birthDate?: Date;
}
