import { UUID } from '../../../types/uuid.type';
import { ExerciseModel } from '../models/exercise.model';

export interface UpdateTemplateParams {
  templateUid: UUID;
  templateName: string;
  difficultyLevelUid: UUID;
  estimatedTime: number;
  exercises: ExerciseModel[];
}
