import { PagedResponse } from '../../../models/paged-response';
import { GroupSessionDTO } from '../models/group-session.dto';

export interface GroupSessionListResponse extends PagedResponse<GroupSessionDTO> {}
