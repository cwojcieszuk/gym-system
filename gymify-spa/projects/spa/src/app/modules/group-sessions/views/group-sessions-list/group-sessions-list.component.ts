import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { GroupSessionDTO } from '../../../../../../../api-client/src/lib/clients/group-sessions/models/group-session.dto';
import { GroupSessionListResponse } from '../../../../../../../api-client/src/lib/clients/group-sessions/responses/group-session-list.response';
import { BaseComponent } from '../../../../shared/components/base.component';
import { GroupSessionsFacade } from '../../+state/group-sessions.facade';
import { filter } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { BookInGroupSessionComponent } from '../../dialogs/book-in-group-session/book-in-group-session.component';

@Component({
  templateUrl: './group-sessions-list.component.html',
  styleUrls: ['./group-sessions-list.component.scss'],
})
export class GroupSessionsListComponent extends BaseComponent {
  displayedColumns = ['hour', 'sessionName', 'place', 'coachName', 'duration', 'slots', 'bookin'];
  dataSource = new MatTableDataSource<GroupSessionDTO>([]);
  groupSessionsResponse?: GroupSessionListResponse;

  constructor(
    private facade: GroupSessionsFacade,
    private dialog: MatDialog
  ) {
    super();

    this.facade.fetchGroupSessions();

    this.observe(this.facade.groupSessionsResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.groupSessionsResponse = value;
        this.dataSource.data = value.content;
      });
  }

  pageChange(pageNumber: number): void {
    this.facade.setFilters({ pageNumber });
  }

  pageSizeChange(pageSize: number): void {
    this.facade.setFilters({ pageSize });
  }

  bookIn(groupSession: GroupSessionDTO): void {
    this.dialog.open(BookInGroupSessionComponent, {
      data: groupSession,
    });
  }
}
