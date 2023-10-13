import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoachDTO } from '../../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { ImageService } from '../../../../shared/services/image.service';

@Component({
  templateUrl: './coach-details.dialog.html',
  styleUrls: ['./coach-details.dialog.scss'],
})
export class CoachDetailsDialog {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { coach: CoachDTO },
    private dialogRef: MatDialogRef<CoachDetailsDialog>,
    public imgService: ImageService,
  ) {
  }

  close(): void {
    this.dialogRef.close();
  }
}
