import { Component, OnInit } from '@angular/core';
import { DashboardFacade } from '../../+state/dashboard.facade';
import { ImageService } from '../../../../shared/services/image.service';
import { ExercisesFacade } from '../../../exercises/+state/exercises.facade';
import { CoachesFacade } from '../../../coaches/+state/coaches.facade';

@Component({
  templateUrl: './dashboard-view.component.html',
  styleUrls: ['./dashboard-view.component.scss'],
})
export class DashboardViewComponent implements OnInit {

  constructor(
    public facade: DashboardFacade,
    public imgService: ImageService,
    public exercisesFacade: ExercisesFacade,
    public coachesFacade: CoachesFacade
  ) {
  }

  ngOnInit(): void {
    this.facade.getPopularCoaches();
    this.facade.getPopularExercises();
    this.facade.getIncomingGroupSessions();
    this.facade.getRecentTemplates();
  }
}
