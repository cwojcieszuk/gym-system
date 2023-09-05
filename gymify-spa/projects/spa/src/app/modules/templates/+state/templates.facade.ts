import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as TemplateActions from './templates.actions';
import * as TemplateSelectors from './templates.selectors';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';
import {
  CreateTemplateParams
} from '../../../../../../api-client/src/lib/clients/templates/params/create-template.params';

@Injectable({ providedIn: 'root' })
export class TemplatesFacade {
  templatesResponse$ = this.store.select(TemplateSelectors.getTemplatesResponse);
  query$ = this.store.select(TemplateSelectors.getQuery);

  exercises$ = this.store.select(TemplateSelectors.getExercises);
  exercisesQuery$ = this.store.select(TemplateSelectors.getExercisesQuery);
  areAllExercisesLoaded$ = this.store.select(TemplateSelectors.areAllExercisesLoaded);
  isLoadingExercises$ = this.store.select(TemplateSelectors.isLoadingExercises);

  constructor(private store: Store) {}

  fetchPersonalTemplates(): void {
    this.store.dispatch(TemplateActions.fetchPersonalTemplates());
  }

  fetchCommunityTemplates(): void {
    this.store.dispatch(TemplateActions.fetchCommunityTemplates());
  }

  setQuery(query: Partial<PagedRequest>): void {
    this.store.dispatch(TemplateActions.setQuery({ query }));
  }

  setExerciseQuery(query: Partial<ExerciseListParams>): void {
    this.store.dispatch(TemplateActions.setExercisesQuery({ query }));
  }

  fetchExercises(): void {
    this.store.dispatch(TemplateActions.fetchExercises());
  }

  nextPage(): void {
    this.store.dispatch(TemplateActions.nextPage());
  }

  createTemplate(params: CreateTemplateParams): void {
    this.store.dispatch(TemplateActions.createTemplate({ params }));
  }

  reset(): void {
    this.store.dispatch(TemplateActions.reset());
  }
}
