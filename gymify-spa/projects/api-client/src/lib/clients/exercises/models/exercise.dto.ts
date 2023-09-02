import { UUID } from '../../../types/uuid.type';

export interface ExerciseDTO {
  exerciseUid: UUID;
  exerciseName: string;
  exerciseGif: any;
  bodyPart: string;
  target: string;
  equipment: string;
  isFavorite: boolean;
}
