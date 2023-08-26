import { UUID } from '../../../types/uuid.type';

export interface ExerciseDTO {
  exerciseUid: UUID;
  exerciseName: string;
  gifUrl: string;
  bodyPart: string;
  target: string;
  equipment: string;
}
