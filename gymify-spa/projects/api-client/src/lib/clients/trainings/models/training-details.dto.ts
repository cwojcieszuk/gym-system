import { ExerciseDetailsDTO } from '../../templates/models/exercise-details.dto';
import { TemplateDetailsDTO } from '../../templates/models/template.details.dto';

export interface TrainingDetailsDTO {
  trainingName: string;
  trainingDate: Date;
  template: TemplateDetailsDTO;
  exercises: ExerciseDetailsDTO[];
  isCyclical: boolean;
}
