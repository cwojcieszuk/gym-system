import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { BaseComponent } from '../../components/base.component';

@Component({
  selector: 'gym-paginator',
  standalone: true,
  imports: [CommonModule, MatInputModule, MatFormFieldModule, MatIconModule, MatButtonModule, MatSelectModule, ReactiveFormsModule],
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss'],
})
export class PaginatorComponent extends BaseComponent {
  @Input()
  pageSizeOptions: number[] = [10, 15, 25];

  @Input()
  page = 1;

  @Input()
  pageSize = 10;

  @Input()
  totalPages!: number;

  @Input()
  totalRecords?: number;

  @Output()
  pageSizeChange = new EventEmitter<number>();

  @Output()
  pageChange = new EventEmitter<number>();

  formControl = new FormControl<number>(10, { nonNullable: true });

  get canPreviousPage(): boolean {
    return this.page === 1;
  }

  get canNextPage(): boolean {
    return this.page === this.totalPages;
  }

  constructor() {
    super();

    this.observe(this.formControl.valueChanges)
      .subscribe(value => this.pageSizeChange.emit(value));
  }

  previousPage(): void {
    if (this.page === 1) {
      return;
    }

    this.page -= 1;
    this.pageChange.emit(this.page);
  }

  nextPage(): void {
    if (this.page === this.totalPages) {
      return;
    }

    this.page += 1;
    this.pageChange.emit(this.page);
  }
}
