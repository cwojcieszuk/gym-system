import { PagedResponse } from '../../../models/paged-response';
import { User } from './user.model';

export interface UserListResponse extends PagedResponse<User> {}
