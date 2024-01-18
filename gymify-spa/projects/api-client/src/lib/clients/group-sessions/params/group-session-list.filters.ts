import { PagedRequest } from '../../../models/paged-request';
import { UUID } from '../../../types/uuid.type';

export interface GroupSessionListFilters extends PagedRequest {
  categoryId?: number;
  coachUid?: UUID;
  name: string;
  date?: Date;
}
