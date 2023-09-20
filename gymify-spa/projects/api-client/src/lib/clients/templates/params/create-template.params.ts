import { ExerciseModel } from '../models/exercise.model';

export interface CreateTemplateParams {
  templateName: string;
  difficultyLevelId: number;
  estimatedTime: number;
  exercises: ExerciseModel[];
}
