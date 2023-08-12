import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UsersFacade } from '../../+state/users.facade';
import { User } from '../../../../../../../api-client/src/lib/clients/users/responses/user.model';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { UserListResponse } from '../../../../../../../api-client/src/lib/clients/users/responses/user-list.response';
import { MatDialog } from '@angular/material/dialog';
import { UserFormComponent } from '../../components/user-form/user-form.component';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import {
  ConfirmationDialogComponent
} from '../../../../shared/components/confirmation-dialog/confirmation-dialog.component';

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
    private facade: UsersFacade,
    private dialog: MatDialog
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

  addUser(): void {
    const dialog = this.dialog.open(UserFormComponent, {
      data: {
        isNew: true,
      }
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(value => this.facade.addUser(value));
  }

  editUser(user: User): void {
    const dialog = this.dialog.open(UserFormComponent, {
      data: {
        isNew: false,
        user,
      },
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(value => this.facade.editUser(value));
  }

  deleteUser(userUid: UUID): void {
    const dialog = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Save changes',
        message: 'Are you sure to delete user?',
      },
    });

    this.observe(dialog.afterClosed())
      .pipe(filter(Boolean))
      .subscribe(value => {
        if (value) {
          this.facade.deleteUser(userUid);
        }
      });
  }
}
