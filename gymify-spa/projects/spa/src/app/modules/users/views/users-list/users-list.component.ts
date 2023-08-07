import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UsersFacade } from '../../+state/users.facade';
import { User } from '../../../../../../../api-client/src/lib/clients/users/responses/user.model';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { UserListResponse } from '../../../../../../../api-client/src/lib/clients/users/responses/user-list.response';

@Component({
  selector: 'gym-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss'],
})
export class UsersListComponent extends BaseComponent implements OnInit {
  displayedColumns = ['firstName', 'lastName', 'role', 'registerDate', 'email', 'actions'];
  dataSource = new MatTableDataSource<User>([]);
  usersResponse?: UserListResponse;

  constructor(
    private facade: UsersFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.facade.fetchUsers();

    this.observe(this.facade.usersResponse$)
      .pipe(filter(Boolean))
      .subscribe(value => { this.dataSource.data = value.content; this.usersResponse = value; });
  }

  pageChange(pageNumber: number): void {
    this.facade.setFilters({ pageNumber });
  }

  pageSizeChange(pageSize: number): void {
    this.facade.setFilters({ pageSize });
  }
}
