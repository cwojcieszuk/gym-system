import { UUID } from '../../../types/uuid.type';

export interface EditGroupSessionParams {
  groupSessionUid: UUID;
  sessionName: string;
  slots: number;
  sessionStartDate: Date;
  sessionEndDate: Date;
  description: string;
  placeId: number;
}
