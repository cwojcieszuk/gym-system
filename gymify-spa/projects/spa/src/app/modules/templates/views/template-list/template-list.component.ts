import { Component, OnInit } from '@angular/core';
import { TemplatesFacade } from '../../+state/templates.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { TemplateDTO } from '../../../../../../../api-client/src/lib/clients/templates/models/template.dto';
import { TemplatesResponse } from '../../../../../../../api-client/src/lib/clients/templates/responses/templates.response';
import { ActivatedRoute, Router } from '@angular/router';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../../../shared/components/confirmation-dialog/confirmation-dialog.component';

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
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog
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

  goToEdit(templateUid: UUID): void {
    this.facade.selectTemplate(templateUid);
    this.router.navigate([templateUid], { relativeTo: this.route });
  }

  shareTemplate(templateUid: UUID): void {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Share template',
        message: 'Are you sure to share template?',
      },
    });

    dialog.afterClosed()
      .pipe(filter(Boolean))
      .subscribe(() => this.facade.shareTemplate(templateUid));
  }

  deleteTemplate(templateUid: UUID): void {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete template',
        message: 'Are you sure to delete template?',
      },
    });

    dialog.afterClosed()
      .pipe(filter(Boolean))
      .subscribe(() => this.facade.deleteTemplate(templateUid));
  }

  importTemplate(templateUid: UUID): void {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Import template',
        message: 'Are you sure to import template?',
      },
    });

    dialog.afterClosed()
      .pipe(filter(Boolean))
      .subscribe(() => this.facade.importTemplate(templateUid));
  }
}
