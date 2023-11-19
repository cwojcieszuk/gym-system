import { UUID } from '../../../types/uuid.type';

export interface CoachHour {
  coachHourUid: UUID;
  coachUid: UUID;
  clientUid?: UUID;
  clientName?: string;
  startDate: Date;
  endDate: Date;
}
