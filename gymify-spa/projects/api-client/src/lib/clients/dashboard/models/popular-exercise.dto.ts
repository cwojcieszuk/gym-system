import { UUID } from '../../../types/uuid.type';

export interface PopularExerciseDTO {
  exerciseUid: UUID;
  exerciseName: string;
  exerciseGif: any;
  bodyPart: string;
  isFavourite: boolean;
}
