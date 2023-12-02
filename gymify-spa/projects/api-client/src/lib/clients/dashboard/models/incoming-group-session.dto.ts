import { UUID } from '../../../types/uuid.type';

export interface IncomingGroupSessionDTO {
  groupSessionUid: UUID;
  groupSessionName: string;
  coachName: string;
  place: string;
  date: Date;
}
