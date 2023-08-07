import { UserRole } from '../../../../../api-client/src/lib/clients/dictionaries/responses/user-role.response';
import { createReducer, on } from '@ngrx/store';
import * as DictionariesActions from './dictionaries.actions';

export const DICTIONARIES_FEATURE_KEY = 'dictionaries';

export interface DictionariesState {
  userRoles: UserRole[];
}

const initialState: DictionariesState = {
  userRoles: [],
};

export const dictionariesReducer = createReducer<DictionariesState>(
  initialState,
  on(DictionariesActions.fetchUserRolesSuccess, (state, payload) => ({
    ...state,
    userRoles: payload.data,
  }))
);
