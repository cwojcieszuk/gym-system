import { createAction, props } from '@ngrx/store';
import { PopularCoachDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/popular-coach.dto';
import { PopularExerciseDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/popular-exercise.dto';
import {
  IncomingGroupSessionDTO
} from '../../../../../../api-client/src/lib/clients/dashboard/models/incoming-group-session.dto';
import { RecentTemplateDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/recent-template.dto';

export const fetchPopularCoaches = createAction(
  '[Dashboard/API] Fetch Popular Coaches'
);

export const fetchPopularCoachesSuccess = createAction(
  '[Dashboard/API] Fetch Popular Coaches Success',
  props<{ response: PopularCoachDTO[] }>()
);

export const fetchPopularCoachesFailure = createAction(
  '[Dashboard/API] Fetch Popular Coaches Failure'
);

export const fetchPopularExercises = createAction(
  '[Dashboard/API] Fetch Popular Exercises'
);

export const fetchPopularExercisesSuccess = createAction(
  '[Dashboard/API] Fetch Popular Exercises Success',
  props<{ response: PopularExerciseDTO[] }>()
);

export const fetchPopularExercisesFailure = createAction(
  '[Dashboard/API] Fetch Popular Exercises Failure'
);

export const fetchIncomingGroupSessions = createAction(
  '[Dashboard/API] Fetch Incoming Group Sessions'
);

export const fetchIncomingGroupSessionsSuccess = createAction(
  '[Dashboard/API] Fetch Incoming Group Sessions Success',
  props<{ response: IncomingGroupSessionDTO[] }>()
);

export const fetchIncomingGroupSessionsFailure = createAction(
  '[Dashboard/API] Fetch Incoming Group Sessions Failure'
);

export const fetchRecentTemplates = createAction(
  '[Dashboard/API] Fetch Recent Templates'
);

export const fetchRecentTemplatesSuccess = createAction(
  '[Dashboard/API] Fetch Recent Templates Success',
  props<{ response: RecentTemplateDTO[] }>()
);

export const fetchRecentTemplatesFailure = createAction(
  '[Dashboard/API] Fetch Recent Templates Failure'
);
