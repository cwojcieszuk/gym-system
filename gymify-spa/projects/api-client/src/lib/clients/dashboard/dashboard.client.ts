import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PopularCoachDTO } from './models/popular-coach.dto';
import { PopularExerciseDTO } from './models/popular-exercise.dto';
import { IncomingGroupSessionDTO } from './models/incoming-group-session.dto';
import { RecentTemplateDTO } from './models/recent-template.dto';

@Injectable({ providedIn: 'root' })
export class DashboardClient {
  private readonly url = 'dashboard';
  private readonly amount = 3;

  constructor(private http: HttpClient) {}

  getPopularCoaches(): Observable<PopularCoachDTO[]> {
    return this.http.get<PopularCoachDTO[]>(`${this.url}/popular-coaches`, { params: { amount: this.amount } });
  }

  getPopularExercises(): Observable<PopularExerciseDTO[]> {
    return this.http.get<PopularExerciseDTO[]>(`${this.url}/popular-exercises`, { params: { amount: this.amount } });
  }

  getIncomingGroupSessions(): Observable<IncomingGroupSessionDTO[]> {
    return this.http.get<IncomingGroupSessionDTO[]>(`${this.url}/incoming-group-sessions`, { params: { amount: this.amount } });
  }

  getRecentTemplates(): Observable<RecentTemplateDTO[]> {
    return this.http.get<RecentTemplateDTO[]>(`${this.url}/recent-templates`);
  }
}
