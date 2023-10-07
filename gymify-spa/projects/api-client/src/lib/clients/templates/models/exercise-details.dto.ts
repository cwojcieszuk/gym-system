import { ExerciseDTO } from '../../exercises/models/exercise.dto';

export interface ExerciseDetailsDTO {
  exercise: ExerciseDTO | null;
  numberOfSets: number;
  numberOfReps: number;
  comments?: string;
}
