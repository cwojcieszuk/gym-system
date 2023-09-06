import { UUID } from '../../../types/uuid.type';
import { ExerciseDTO } from '../../exercises/models/exercise.dto';

export interface TemplateDetailsDTO {
  templateUid: UUID;
  templateName: string;
  difficultyLevelUid: UUID;
  difficultyLevelName: string;
  estimatedTime: number;
  isShared: boolean;
  userUid: UUID;
  exercises: { exercise: ExerciseDTO |null; numberOfSets: number; numberOfReps: number; comments?: string }[];
}
