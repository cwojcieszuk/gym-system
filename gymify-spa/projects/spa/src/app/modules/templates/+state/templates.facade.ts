import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as TemplateActions from './templates.actions';
import * as TemplateSelectors from './templates.selectors';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';

@Injectable({ providedIn: 'root' })
export class TemplatesFacade {
  templatesResponse$ = this.store.select(TemplateSelectors.getTemplatesResponse);
  query$ = this.store.select(TemplateSelectors.getQuery);

  constructor(private store: Store) {}

  fetchTemplates(): void {
    this.store.dispatch(TemplateActions.fetchTemplates());
  }

  setQuery(query: Partial<PagedRequest>): void {
    this.store.dispatch(TemplateActions.setQuery({ query }));
  }
}
