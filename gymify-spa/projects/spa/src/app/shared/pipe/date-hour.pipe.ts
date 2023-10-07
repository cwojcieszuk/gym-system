import { Pipe, PipeTransform } from '@angular/core';
import { formatDate } from '@angular/common';

@Pipe({
  name: 'dateHour',
  standalone: true,
})
export class DateHourPipe implements PipeTransform {
  transform(value: Date): string {
    return formatDate(value, 'shortTime', 'en-US');
  }
}
