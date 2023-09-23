import { UUID } from '../../../types/uuid.type';

export interface CreateTrainingParams {
  trainingName: string;
  trainingDate: Date;
  templateUid: UUID;
}
