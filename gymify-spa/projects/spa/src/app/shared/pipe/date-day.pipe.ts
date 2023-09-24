import { Pipe, PipeTransform } from '@angular/core';
import { formatDate } from '@angular/common';

@Pipe({
  name: 'dateDay',
  standalone: true,
})
export class DateDayPipe implements PipeTransform {
  transform(value: Date): string {
    return formatDate(value, 'EEEE', 'en-US');
  }
}
