import { ExerciseDTO } from '../models/exercise.dto';
import { PagedResponse } from '../../../models/paged-response';

export interface ExerciseListResponse extends PagedResponse<ExerciseDTO> { }
