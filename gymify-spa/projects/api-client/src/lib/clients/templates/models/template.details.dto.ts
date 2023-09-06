import { UUID } from '../../../types/uuid.type';
import { ExerciseModel } from './exercise.model';

export interface TemplateDetailsDTO {
  templateUid: UUID;
  templateName: string;
  difficultyLevelUid: UUID;
  difficultyLevelName: string;
  estimatedTime: number;
  isShared: boolean;
  userUid: UUID;
  exercises: ExerciseModel[];
}
