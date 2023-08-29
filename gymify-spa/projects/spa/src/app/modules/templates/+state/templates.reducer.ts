import { createReducer } from '@ngrx/store';

export const TEMPLATES_FEATURE_KEY = 'templates';

export interface TemplatesState {
  personalTemplates: any;
}

const initialState: TemplatesState = {
  personalTemplates: ''
}

export const templatesReducer = createReducer(
  initialState,
);
