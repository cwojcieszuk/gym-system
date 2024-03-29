import { Component, inject, OnInit } from '@angular/core';
import { CoachesFacade } from '../../+state/coaches.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { ImageService } from '../../../../shared/services/image.service';
import { PagedResponse } from '../../../../../../../api-client/src/lib/models/paged-response';
import { CoachDTO } from '../../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { filter } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { CoachDetailsDialog } from '../../components/coach-details/coach-details.dialog';

@Component({
  templateUrl: './coaches-list.component.html',
  styleUrls: ['./coaches-list.component.scss'],
})
export class CoachesListComponent extends BaseComponent implements OnInit {
  coachesFacade = inject(CoachesFacade);
  imgService = inject(ImageService);

  coachesResponse?: PagedResponse<CoachDTO>;

  constructor(
    private dialog: MatDialog
  ) {
    super();
  }

  ngOnInit(): void {
    this.coachesFacade.fetchCoaches();

    this.observe(this.coachesFacade.coachesResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => { this.coachesResponse = value; });
  }

  pageChange(event: number): void {
    this.coachesFacade.pageChange(event);
  }

  openCoachDialog(coach: CoachDTO): void {
    this.dialog.open(CoachDetailsDialog, {
      data: {
        coach,
      },
    });
  }
}
