import { createAction, props } from '@ngrx/store';
import { UserRole } from '../../../../../api-client/src/lib/clients/dictionaries/responses/user-role.response';
import { BodyPartDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/body-part.dto';
import { EquipmentDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/equipment.dto';
import { TargetDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/target.dto';
import { DifficultyLevelDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/difficulty-level.dto';
import { CoachCategoryDTO } from '../../../../../api-client/src/lib/clients/dictionaries/models/coach-category.dto';

export const fetchUserRoles = createAction(
  '[Dictionaries/API] Fetch User Roles'
);

export const fetchUserRolesSuccess = createAction(
  '[Dictionaries/API] Fetch User Roles Success',
  props<{ data: UserRole[] }>()
);

export const fetchUserRolesFailure = createAction(
  '[Dictionaries/API] Fetch User Roles Failure'
);

export const fetchBodyParts = createAction(
  '[Dictionaries/API] Fetch Body Parts'
);

export const fetchBodyPartsSuccess = createAction(
  '[Dictionaries/API] Fetch Body Parts Success',
  props<{ data: BodyPartDTO[] }>()
);

export const fetchBodyPartsFailure = createAction(
  '[Dictionaries/API] Fetch Body Parts Failure'
);

export const fetchEquipments = createAction(
  '[Dictionaries/API] Fetch Equipments'
);

export const fetchEquipmentsSuccess = createAction(
  '[Dictionaries/API] Fetch Equipments Success',
  props<{ data: EquipmentDTO[] }>()
);

export const fetchEquipmentsFailure = createAction(
  '[Dictionaries/API] Fetch Equipments Failure'
);

export const fetchTargets = createAction(
  '[Dictionaries/API] Fetch Targets'
);

export const fetchTargetsSuccess = createAction(
  '[Dictionaries/API] Fetch Targets Success',
  props<{ data: TargetDTO[] }>()
);

export const fetchTargetsFailure = createAction(
  '[Dictionaries/API] Fetch Targets Failure'
);

export const fetchDifficultyLevels = createAction(
  '[Dictionaries/API] Fetch Difficulty Levels'
);

export const fetchDifficultyLevelsSuccess = createAction(
  '[Dictionaries/API] Fetch Difficulty Levels Success',
  props<{ data: DifficultyLevelDTO[] }>()
);

export const fetchDifficultyLevelsFailure = createAction(
  '[Dictionaries/API] Fetch Difficulty Levels Failure'
);

export const fetchCoachCategories = createAction(
  '[Dictionaries/API] Fetch Coach Categories'
);

export const fetchCoachCategoriesSuccess = createAction(
  '[Dictionaries/API] Fetch Coach Categories Success',
  props<{ data: CoachCategoryDTO[] }>(),
);

export const fetchCoachCategoriesFailure = createAction(
  '[Dictionaries/API] Fetch Coach Categories Failure'
);
