import { UUID } from '../../../types/uuid.type';

export interface TrainingDTO {
  trainingUid: UUID;
  trainingName: string;
  templateName: string;
  trainingDate: Date;
  estimatedTime: number;
}
