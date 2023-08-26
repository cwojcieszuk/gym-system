import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstLetterUppercase',
  standalone: true,
})
export class FirstLetterUppercasePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): string {
    return `${value[0].toUpperCase()}${value.slice(1, value.length)}`;
  }
}
