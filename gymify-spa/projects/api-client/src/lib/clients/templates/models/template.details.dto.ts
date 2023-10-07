import { UUID } from '../../../types/uuid.type';
import { ExerciseDetailsDTO } from './exercise-details.dto';

export interface TemplateDetailsDTO {
  templateUid: UUID;
  templateName: string;
  difficultyLevelId: number;
  difficultyLevelName: string;
  estimatedTime: number;
  isShared: boolean;
  userUid: UUID;
  exercises: ExerciseDetailsDTO[];
}
