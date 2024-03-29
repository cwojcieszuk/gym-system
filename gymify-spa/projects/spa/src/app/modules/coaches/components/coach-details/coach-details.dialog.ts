import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoachDTO } from '../../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { ImageService } from '../../../../shared/services/image.service';
import { CoachesFacade } from '../../+state/coaches.facade';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { BaseComponent } from '../../../../shared/components/base.component';

@Component({
  templateUrl: './coach-details.dialog.html',
  styleUrls: ['./coach-details.dialog.scss'],
})
export class CoachDetailsDialog extends BaseComponent {
  minDate = new Date();
  selectedHour?: UUID;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { coach: CoachDTO },
    private dialogRef: MatDialogRef<CoachDetailsDialog>,
    public imgService: ImageService,
    public facade: CoachesFacade
  ) {
    super();

    this.observe(this.facade.selectedCoachHour$)
      .subscribe(value => { this.selectedHour = value });
  }

  close(): void {
    this.dialogRef.close();
  }
}
