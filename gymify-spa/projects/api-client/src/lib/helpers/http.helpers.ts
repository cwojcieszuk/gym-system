import { pl } from 'date-fns/locale';
import { format } from 'date-fns';

export class HttpHelpers {
  static getParamsWithFormattedDates<T extends {}>(params: T): object {
    return Object.fromEntries(Object.entries(params)
      .map(entry => {
        const value = entry[1];

        if(value instanceof Date) {
          return [entry[0], this.formatDate(value)];
        }

        return entry;
      }));
  }

  static formatDate(date: Date): string {
    const pattern = "yyyy-MM-dd'T'HH:mm:ss";

    return format(date, pattern, { locale: pl });
  }
}
