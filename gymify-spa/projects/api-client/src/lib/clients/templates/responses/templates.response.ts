import { PagedResponse } from '../../../models/paged-response';
import { TemplateDTO } from '../models/template.dto';

export interface TemplatesResponse extends PagedResponse<TemplateDTO> {}
