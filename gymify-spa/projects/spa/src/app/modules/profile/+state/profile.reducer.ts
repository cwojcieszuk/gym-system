import { User } from '../../../../../../api-client/src/lib/clients/users/responses/user.model';
import { createReducer } from '@ngrx/store';

export const PROFILE_FEATURE_KEY = 'profile';

export interface ProfileState {
  user?: User;
}

const initialState: ProfileState = {

};

export const profileReducer = createReducer(
  initialState
);
