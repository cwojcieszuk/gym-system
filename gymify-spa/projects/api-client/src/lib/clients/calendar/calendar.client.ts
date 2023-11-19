import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CalendarEventDTO } from './models/calendar-event.dto';
import { mapToHttpParams } from '../../mappers/map-to-http-params';

@Injectable({ providedIn: 'root' })
export class CalendarClient {
  private readonly url = 'calendar';

  constructor(
    private http: HttpClient
  ) {}

  getCalendarEvents(date: Date): Observable<CalendarEventDTO[]> {
    return this.http.get<CalendarEventDTO[]>(this.url, { params: mapToHttpParams(date) });
  }
}
