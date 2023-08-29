import { Component, OnInit } from '@angular/core';
import { TemplatesFacade } from '../../+state/templates.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { TemplateDTO } from '../../../../../../../api-client/src/lib/clients/templates/models/template.dto';
import {
  TemplatesResponse
} from '../../../../../../../api-client/src/lib/clients/templates/responses/templates.response';

@Component({
  templateUrl: './template-list.component.html',
  styleUrls: ['./template-list.component.scss']
})
export class TemplateListComponent extends BaseComponent implements OnInit {
  displayedColumns = ['templateName', 'difficultyLevel', 'estimatedTime', 'actions'];
  dataSource = new MatTableDataSource<TemplateDTO>([]);
  templatesResponse?: TemplatesResponse;

  constructor(
    private facade: TemplatesFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.facade.fetchTemplates();

    this.observe(this.facade.templatesResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => { this.dataSource.data = value.content; this.templatesResponse = value; });
  }

  pageChange(pageNumber: number): void {
    this.facade.setQuery({ pageNumber });
  }

  pageSizeChange(pageSize: number): void {
    this.facade.setQuery({ pageSize });
  }
}
