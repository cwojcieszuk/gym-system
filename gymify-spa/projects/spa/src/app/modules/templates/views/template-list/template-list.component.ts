import { Component, OnInit } from '@angular/core';
import { TemplatesFacade } from '../../+state/templates.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { TemplateDTO } from '../../../../../../../api-client/src/lib/clients/templates/models/template.dto';
import { TemplatesResponse } from '../../../../../../../api-client/src/lib/clients/templates/responses/templates.response';
import { ActivatedRoute } from '@angular/router';

@Component({
  templateUrl: './template-list.component.html',
  styleUrls: ['./template-list.component.scss'],
})
export class TemplateListComponent extends BaseComponent implements OnInit {
  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<TemplateDTO>([]);
  templatesResponse?: TemplatesResponse;

  isCommunity = false;

  constructor(
    private facade: TemplatesFacade,
    private route: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.observe(this.route.data)
      .subscribe(value => {
        this.isCommunity = value['isCommunity'];
      });

    if (this.isCommunity) {
      this.displayedColumns = ['templateName', 'difficultyLevel', 'author', 'estimatedTime', 'actions'];
      this.facade.fetchCommunityTemplates();
    } else {
      this.displayedColumns = ['templateName', 'difficultyLevel', 'estimatedTime', 'actions'];
      this.facade.fetchPersonalTemplates();
    }

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
