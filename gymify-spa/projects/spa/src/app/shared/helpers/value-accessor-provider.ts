import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { forwardRef } from '@angular/core';

// eslint-disable-next-line @typescript-eslint/explicit-function-return-type
export const valueAccessorProvider = <T>(type: T) => ({
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => type),
  multi: true,
});
