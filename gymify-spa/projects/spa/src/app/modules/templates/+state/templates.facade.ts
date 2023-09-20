import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as TemplateActions from './templates.actions';
import * as TemplateSelectors from './templates.selectors';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';
import {
  CreateTemplateParams
} from '../../../../../../api-client/src/lib/clients/templates/params/create-template.params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';
import {
  UpdateTemplateParams
} from '../../../../../../api-client/src/lib/clients/templates/params/update-template.params';

@Injectable({ providedIn: 'root' })
export class TemplatesFacade {
  templatesResponse$ = this.store.select(TemplateSelectors.getTemplatesResponse);
  query$ = this.store.select(TemplateSelectors.getQuery);

  exercises$ = this.store.select(TemplateSelectors.getExercises);
  exercisesQuery$ = this.store.select(TemplateSelectors.getExercisesQuery);
  areAllExercisesLoaded$ = this.store.select(TemplateSelectors.areAllExercisesLoaded);
  isLoadingExercises$ = this.store.select(TemplateSelectors.isLoadingExercises);

  template$ = this.store.select(TemplateSelectors.getTemplate);
  selectedTemplateUid$ = this.store.select(TemplateSelectors.getSelectedTemplateUid);

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

  selectTemplate(templateUid: UUID): void {
    this.store.dispatch(TemplateActions.selectTemplate({ templateUid }));
  }

  fetchTemplate(): void {
    this.store.dispatch(TemplateActions.fetchTemplate());
  }

  shareTemplate(templateUid: UUID): void {
    this.store.dispatch(TemplateActions.shareTemplate({ templateUid }));
  }

  deleteTemplate(templateUid: UUID): void {
    this.store.dispatch(TemplateActions.deleteTemplate({ templateUid }));
  }

  updateTemplate(params: UpdateTemplateParams): void {
    this.store.dispatch(TemplateActions.updateTemplate({ params }));
  }

  importTemplate(templateUid: UUID): void {
    this.store.dispatch(TemplateActions.importTemplate({ templateUid }));
  }

  reset(): void {
    this.store.dispatch(TemplateActions.reset());
  }
}
