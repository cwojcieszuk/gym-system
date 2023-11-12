import { UserRole } from '../../../../../api-client/src/lib/clients/dictionaries/responses/user-role.response';
import { createReducer, on } from '@ngrx/store';
import * as DictionariesActions from './dictionaries.actions';
import { BodyPartDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/body-part.dto';
import { EquipmentDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/equipment.dto';
import { TargetDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/target.dto';
import { DifficultyLevelDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/difficulty-level.dto';
import { CoachCategoryDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/coach-category.dto';
import { PlaceDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/place.dto';

export const DICTIONARIES_FEATURE_KEY = 'dictionaries';

export interface DictionariesState {
  userRoles: UserRole[];
  bodyParts: BodyPartDTO[];
  equipments: EquipmentDTO[];
  targets: TargetDTO[];
  difficultyLevels: DifficultyLevelDTO[];
  coachCategories: CoachCategoryDTO[];
  places: PlaceDTO[];
}

const initialState: DictionariesState = {
  userRoles: [],
  bodyParts: [],
  equipments: [],
  targets: [],
  difficultyLevels: [],
  coachCategories: [],
  places: [],
};

export const dictionariesReducer = createReducer<DictionariesState>(
  initialState,
  on(DictionariesActions.fetchUserRolesSuccess, (state, payload) => ({
    ...state,
    userRoles: payload.data,
  })),
  on(DictionariesActions.fetchBodyPartsSuccess, (state, payload) => ({
    ...state,
    bodyParts: payload.data,
  })),
  on(DictionariesActions.fetchEquipmentsSuccess, (state, payload) => ({
    ...state,
    equipments: payload.data,
  })),
  on(DictionariesActions.fetchTargetsSuccess, (state, payload) => ({
    ...state,
    targets: payload.data,
  })),
  on(DictionariesActions.fetchDifficultyLevelsSuccess, (state, payload) => ({
    ...state,
    difficultyLevels: payload.data,
  })),
  on(DictionariesActions.fetchCoachCategoriesSuccess, (state, payload) => ({
    ...state,
    coachCategories: payload.data,
  })),
  on(DictionariesActions.fetchPlacesSuccess, (state, payload) => ({
    ...state,
    places: payload.data,
  }))
);
