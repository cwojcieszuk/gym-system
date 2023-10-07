import { createAction, props } from '@ngrx/store';
import { PagedResponse } from '../../../../../../api-client/src/lib/models/paged-response';
import { CoachDTO } from '../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { GetCoachesParams } from '../../../../../../api-client/src/lib/clients/coaches/params/get-coaches.params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

export const fetchCoaches = createAction(
  '[Coaches/API] Fetch Coaches'
);

export const fetchCoachesSuccess = createAction(
  '[Coaches/API] Fetch Coaches Success',
  props<{ response: PagedResponse<CoachDTO> }>()
);

export const fetchCoachesFailure = createAction(
  '[Coaches/API] Fetch Coaches Failure'
);

export const setCoachesQuery = createAction(
  '[Coaches] Set Coaches Query',
  props<{ query: Partial<GetCoachesParams> }>()
);

export const pageChange = createAction(
  '[Coaches] Page Change',
  props<{ page: number }>()
);

export const likeCoach = createAction(
  '[Coaches/API] Like Coach',
  props<{ coachUid: UUID }>()
);

export const likeCoachSuccess = createAction(
  '[Coaches/API] Like Coach Success',
  props<{ coachUid: UUID }>()
);

export const likeCoachFailure = createAction(
  '[Coaches/API] Like Coach Failure'
);

export const dislikeCoach = createAction(
  '[Coaches/API] Dislike Coach',
  props<{ coachUid: UUID }>()
);

export const dislikeCoachSuccess = createAction(
  '[Coaches/API] Dislike Coach Success',
  props<{ coachUid: UUID }>()
);

export const dislikeCoachFailure = createAction(
  '[Coaches/API] Dislike Coach Failure'
);
