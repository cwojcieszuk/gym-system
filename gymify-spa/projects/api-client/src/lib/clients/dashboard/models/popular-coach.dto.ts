import { UUID } from '../../../types/uuid.type';

export interface PopularCoachDTO {
  coachUid: UUID;
  coachName: string;
  avatar: any;
  categories: string[];
  isFavourite: boolean;
}
