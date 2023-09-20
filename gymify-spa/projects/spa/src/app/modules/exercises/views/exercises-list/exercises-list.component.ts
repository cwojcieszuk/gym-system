import { Component, OnInit } from '@angular/core';
import { ExercisesFacade } from '../../+state/exercises.facade';
import {
  ExerciseListResponse
} from '../../../../../../../api-client/src/lib/clients/exercises/responses/exercise-list.response';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { ImageService } from '../../../../shared/services/image.service';

@Component({
  templateUrl: './exercises-list.component.html',
  styleUrls: ['./exercises-list.component.scss']
})
export class ExercisesListComponent extends BaseComponent implements OnInit {
  exerciseResponse?: ExerciseListResponse;

  constructor(
    public facade: ExercisesFacade,
    public imgService: ImageService
  ) {
    super();
  }

  ngOnInit(): void {
    this.facade.fetchExercises();

    this.observe(this.facade.exerciseResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => { this.exerciseResponse = value });
  }

  pageChange(pageNumber: number): void {
    this.facade.setFilters({ pageNumber });
  }
}
