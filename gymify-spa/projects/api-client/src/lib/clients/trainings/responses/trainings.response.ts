import { PagedResponse } from '../../../models/paged-response';
import { TrainingDTO } from '../models/training.dto';

export interface TrainingsResponse extends PagedResponse<TrainingDTO> {}
