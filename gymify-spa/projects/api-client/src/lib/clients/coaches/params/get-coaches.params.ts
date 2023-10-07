import { PagedRequest } from '../../../models/paged-request';

export interface GetCoachesParams extends PagedRequest {
  name?: string;
  categoryId?: number;
}
