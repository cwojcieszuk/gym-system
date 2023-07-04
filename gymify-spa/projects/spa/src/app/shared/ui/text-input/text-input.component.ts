import {
  Component, Inject, Injector, Input, OnInit
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseControlComponent } from '../base-control.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ReactiveFormsModule } from '@angular/forms';
import { valueAccessorProvider } from '../../helpers/value-accessor-provider';

@Component({
  selector: 'gym-text-input',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatTooltipModule,
    ReactiveFormsModule,
  ],
  providers: [valueAccessorProvider(TextInputComponent)],
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.scss'],
})
export class TextInputComponent extends BaseControlComponent implements OnInit {
  @Input()
  readonly?: boolean;
  @Input()
  type: 'text' | 'password' | 'date' | 'number' | 'textarea' = 'text';
  @Input()
  label?: string;
  @Input()
  placeholder?: string;
  @Input()
  required = false;
  @Input()
  color?: 'primary' | 'accent' | 'warn';
  @Input()
  rows?: string | number;
  @Input()
  cols?: string | number;
  @Input()
  tooltip?: string;
  @Input()
  small = false;

  constructor(@Inject(Injector) injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
    this.init();
  }

  public override writeValue(obj?: string | string[] | null | number): void {
    if (this.type === 'number') {
      obj = obj != null ? +obj : null;
    }
    if (this.type === 'date' && obj === '') {
      obj = null;
    }
    super.writeValue(obj);
  }
}
