import { PagedRequest } from '../../../models/paged-request';

export interface ExerciseListParams extends PagedRequest {
  bodyPartId?: number;
  equipmentId?: number;
  targetId?: number;
  name?: string;
}
