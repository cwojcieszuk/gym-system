import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstLetterUppercase',
  standalone: true,
})
export class FirstLetterUppercasePipe implements PipeTransform {

  transform(value: string | undefined, ...args: unknown[]): string {
    if (!value) {
      return '';
    }

    return `${value[0].toUpperCase()}${value.slice(1, value.length)}`;
  }
}
