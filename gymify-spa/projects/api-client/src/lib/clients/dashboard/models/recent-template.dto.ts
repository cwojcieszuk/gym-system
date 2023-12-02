import { UUID } from '../../../types/uuid.type';

export interface RecentTemplateDTO {
  templateUid: UUID;
  templateName: string;
  difficultyLevelId: string;
  author: string;
}
