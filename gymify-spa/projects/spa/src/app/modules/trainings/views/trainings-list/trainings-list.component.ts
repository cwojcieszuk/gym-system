import { Component, OnInit } from '@angular/core';
import { TrainingsFacade } from '../../+state/trainings.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { MatTableDataSource } from '@angular/material/table';
import { TrainingDTO } from '../../../../../../../api-client/src/lib/clients/trainings/models/training.dto';
import { filter } from 'rxjs';
import { TrainingsResponse } from '../../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../../../shared/components/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'gym-trainings-list',
  templateUrl: './trainings-list.component.html',
  styleUrls: ['./trainings-list.component.scss'],
})
export class TrainingsListComponent extends BaseComponent implements OnInit {
  displayedColumns = ['trainingName', 'templateName', 'day', 'hour', 'estimatedTime', 'actions'];
  datasource = new MatTableDataSource<TrainingDTO>([]);
  trainingsResponse?: TrainingsResponse;

  constructor(
    private facade: TrainingsFacade,
    private router: Router,
    private dialog: MatDialog
  ) {
    super();
  }

  ngOnInit(): void {
    this.facade.fetchTrainings();

    this.observe(this.facade.templateResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.datasource.data = value.content;
        this.trainingsResponse = value;
      });
  }

  pageChange(pageNumber: number): void {
    this.facade.setQuery({ pageNumber });
  }

  pageSizeChange(pageSize: number): void {
    this.facade.setQuery({ pageSize });
  }

  navigateToTraining(uid: UUID): void {
    this.router.navigate(['trainings', uid]);
  }

  deleteTraining(trainingUid: UUID): void {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete training',
        message: 'Are you sure to delete training?',
      },
    });

    dialog.afterClosed()
      .pipe(filter(Boolean))
      .subscribe(() => this.facade.deleteTraining(trainingUid));
  }
}
