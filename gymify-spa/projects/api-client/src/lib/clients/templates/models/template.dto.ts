import { UUID } from '../../../types/uuid.type';

export interface TemplateDTO {
  templateUid: UUID;
  templateName: string;
  difficultyLevel: string;
  estimatedTime: number;
  firstName: string;
  lastName: string;
}
