import { UUID } from '../../../types/uuid.type';

export interface EditUserParams {
  userUid: UUID;
  firstName: string;
  lastName: string;
  email: string;
  login: string;
  role: string;
  birthDate: Date;
  gender: string;
  password?: string;
  currentPassword?: string;
  phoneNumber: string;
}
