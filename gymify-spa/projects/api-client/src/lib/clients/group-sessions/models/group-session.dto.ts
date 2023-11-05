import { UUID } from '../../../types/uuid.type';

export interface GroupSessionDTO {
  groupSessionUid: UUID;
  groupSessionName: string;
  hour: number;
  place: string;
  coachName: string;
  duration: string;
  availableSlots: number;
  takenSlots: number;
}
