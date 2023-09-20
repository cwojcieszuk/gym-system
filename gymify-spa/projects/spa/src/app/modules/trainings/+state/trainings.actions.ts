import { createAction, props } from '@ngrx/store';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TrainingsResponse } from '../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';

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
  '[Trainings/API] Set Query',
  props<Partial<PagedRequest>>()
);
