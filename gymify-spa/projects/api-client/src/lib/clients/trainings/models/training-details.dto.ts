import { UUID } from '../../../types/uuid.type';
import { ExerciseDetailsDTO } from '../../templates/models/exercise-details.dto';

export interface TrainingDetailsDTO {
  trainingName: string;
  trainingDate: Date;
  templateUid: UUID;
  exercises: ExerciseDetailsDTO[];
}
