import { UUID } from '../../../types/uuid.type';
import { ExerciseModel } from '../models/exercise.model';

export interface UpdateTemplateParams {
  templateUid: UUID;
  templateName: string;
  difficultyLevelId: number;
  estimatedTime: number;
  exercises: ExerciseModel[];
}
