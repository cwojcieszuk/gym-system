import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CalendarEventDTO } from './models/calendar-event.dto';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { AddCoachHourParams } from './params/add-coach-hour.params';
import { EmptyResponse } from '../../types/empty.response';

@Injectable({ providedIn: 'root' })
export class CalendarClient {
  private readonly url = 'calendar';

  constructor(
    private http: HttpClient
  ) {}

  getCalendarEvents(date: Date): Observable<CalendarEventDTO[]> {
    return this.http.get<CalendarEventDTO[]>(this.url, { params: mapToHttpParams({ date }) });
  }

  addCoachHour(params: AddCoachHourParams): Observable<EmptyResponse> {
    return this.http.post(`${this.url}/coach-hours`, params);
  }
}
