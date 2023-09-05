import { UUID } from '../../../types/uuid.type';

export interface ExerciseModel {
  exerciseUid: UUID;
  numberOfSets: number;
  numberOfReps: number;
  comments?: string;
}
