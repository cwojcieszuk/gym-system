import { UUID } from '../../../types/uuid.type';

export interface User {
  userUid: UUID;
  firstName: string;
  lastName: string;
  role: string;
  registerDate: Date;
  email: string;
}
