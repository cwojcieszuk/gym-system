import { UUID } from '../../../types/uuid.type';

export interface UpdateTrainingParams {
  trainingUid: UUID;
  trainingName: string;
  trainingDate: Date;
  templateUid: UUID;
  isCyclical: boolean;
}
