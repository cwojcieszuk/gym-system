import { UUID } from '../../../types/uuid.type';

export interface CoachDTO {
  coachUid: UUID;
  coachName: string;
  gender: string;
  avatar: any | null;
  categories: string[];
  description: string;
  isFavorite: boolean;
}
