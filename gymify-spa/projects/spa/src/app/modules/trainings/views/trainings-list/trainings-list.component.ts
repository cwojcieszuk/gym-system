import { Component, OnInit } from '@angular/core';
import { TrainingsFacade } from '../../+state/trainings.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { MatTableDataSource } from '@angular/material/table';
import { TrainingDTO } from '../../../../../../../api-client/src/lib/clients/trainings/models/training.dto';
import { filter } from 'rxjs';
import {
  TrainingsResponse
} from '../../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';

@Component({
  selector: 'gym-trainings-list',
  templateUrl: './trainings-list.component.html',
  styleUrls: ['./trainings-list.component.scss']
})
export class TrainingsListComponent extends BaseComponent implements OnInit {
  displayedColumns = ['trainingName', 'templateName', 'day', 'hour', 'estimatedTime'];
  datasource = new MatTableDataSource<TrainingDTO>([]);
  trainingsResponse?: TrainingsResponse;

  constructor(
    private facade: TrainingsFacade
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
}
