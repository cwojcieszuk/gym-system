import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GroupSessionDTO } from '../../../../../../../api-client/src/lib/clients/group-sessions/models/group-session.dto';
import { GroupSessionsFacade } from '../../+state/group-sessions.facade';

@Component({
  templateUrl: './book-in-group-session.component.html',
  styleUrls: ['./book-in-group-session.component.scss'],
})
export class BookInGroupSessionComponent {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: GroupSessionDTO,
    private dialogRef: MatDialogRef<BookInGroupSessionComponent>,
    private facade: GroupSessionsFacade
  ) {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  resign(): void {
    this.facade.resign(this.data.groupSessionUid);

    this.dialogRef.close();
  }

  bookIn(): void {
    this.facade.bookIn(this.data.groupSessionUid);

    this.dialogRef.close();
  }
}
