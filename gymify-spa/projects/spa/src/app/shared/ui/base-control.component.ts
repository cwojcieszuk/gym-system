import { Injector } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormControlDirective,
  FormControlName,
  FormGroupDirective,
  NgControl
} from '@angular/forms';

export class BaseControlComponent implements ControlValueAccessor {
  id = Math.random().toString(36).substring(2);
  value: string | string[] | undefined | null | number;
  touched = false;
  disabled = false;

  control?: FormControl;
  controlName?: string | number | null;

  onChange = (val?: string | string[] | null | number) => val;
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  onTouched = () => {};

  get hasError() {
    return this.getErrors().length > 0;
  }

  get error() {
    const errors = this.getErrors();
    return errors[0];
  }

  get errorParams() {
    const errors = this.errors;
    const currentError = this.error;
    const errorParams = errors[currentError];
    if (typeof errorParams === 'object') {
      return errorParams;
    } else {
      return {};
    }
  }

  constructor(private injector?: Injector) {}

  public init() {
    if (!this.injector) {
      return;
    }
    const injectedControl = this.injector.get(NgControl, null);

    switch (injectedControl?.constructor) {
      case NgControl:
        this.control = injectedControl.control as FormControl;
        this.controlName = injectedControl.name;
        break;
      case FormControlName:
        this.controlName = (injectedControl as FormControlName).name;
        this.control = this.injector
          .get(FormGroupDirective)
          .getControl(injectedControl as FormControlName);
        break;
      case FormControlDirective:
        this.controlName = (injectedControl as FormControlDirective).name;
        this.control = (injectedControl as FormControlDirective)
          .form as FormControl;
        break;
    }
  }

  public writeValue(obj?: string | string[] | null | number) {
    const currentValue = this.value;
    if (currentValue === obj) {
      return;
    }

    this.value = obj;
    this.onChange(obj);
  }

  get errors() {
    return this.control?.errors ?? {};
  }

  getErrors() {
    return Object.keys(this.errors);
  }

  public registerOnChange(fn: any) {
    this.onChange = fn;
  }

  public registerOnTouched(fn: any) {
    this.onTouched = fn;
  }

  public setDisabledState(isDisabled: boolean) {
    this.disabled = isDisabled;
  }

  public markTouched() {
    if (this.touched) {
      return;
    }

    this.touched = true;
    this.onTouched();
  }

  handleInputChange(event: Event) {
    this.markTouched();
    const target = event.target as HTMLInputElement;
    this.writeValue(target.value);
    this.control?.markAsDirty();
  }

  extend(parent: BaseControlComponent) {
    this.id = parent.id;
    this.registerOnChange = parent.registerOnChange;
    this.registerOnTouched = parent.registerOnTouched;
    this.setDisabledState = parent.setDisabledState;
  }
}
