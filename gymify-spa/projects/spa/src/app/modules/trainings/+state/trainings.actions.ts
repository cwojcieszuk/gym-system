import { createAction, props } from '@ngrx/store';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TrainingsResponse } from '../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';
import { CreateTrainingParams } from '../../../../../../api-client/src/lib/clients/trainings/params/create-training.params';
import { TrainingDetailsDTO } from '../../../../../../api-client/src/lib/clients/trainings/models/training-details.dto';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';


export const fetchTrainings = createAction(
  '[Trainings/API] Fetch Trainings'
);

export const fetchTrainingsSuccess = createAction(
  '[Trainings/API] Fetch Trainings Success',
  props<TrainingsResponse>()
);

export const fetchTrainingsFailure = createAction(
  '[Trainings/API] Fetch Trainings Failure'
);

export const setQuery = createAction(
  '[Trainings] Set Query',
  props<{ query: Partial<PagedRequest> }>()
);

export const createTraining = createAction(
  '[Trainings/API] Create Training',
  props<CreateTrainingParams>()
);

export const createTrainingSuccess = createAction(
  '[Trainings/API] Create Training Success'
);

export const createTrainingFailure = createAction(
  '[Trainings/API] Create Training Failure'
);

export const selectTraining = createAction(
  '[Trainings] Select Training',
  props<{ trainingUid: UUID }>()
);

export const fetchTrainingDetails = createAction(
  '[Trainings/API] Fetch Training Details'
);

export const fetchTrainingDetailsSuccess = createAction(
  '[Trainings/API] Fetch Training Details Success',
  props<TrainingDetailsDTO>()
);

export const fetchTrainingDetailsFailure = createAction(
  '[Trainings/API] Fetch Training Details Failure'
);

export const updateTraining = createAction(
  '[Trainings/API] Update Training',
  props<{ trainingName: string; trainingDate: Date; templateUid: UUID }>()
);

export const updateTrainingSuccess = createAction(
  '[Trainings/API] Update Training Success'
);

export const updateTrainingFailure = createAction(
  '[Trainings/API] Update Training Failure'
);
