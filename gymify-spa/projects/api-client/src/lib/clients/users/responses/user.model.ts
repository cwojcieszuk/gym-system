import { UUID } from '../../../types/uuid.type';

export interface User {
  userUid: UUID;
  firstName: string;
  lastName: string;
  role: string;
  birthDate: Date;
  email: string;
  gender: string;
  phoneNumber: string;
  login: string;
  canDelete: boolean;
}
