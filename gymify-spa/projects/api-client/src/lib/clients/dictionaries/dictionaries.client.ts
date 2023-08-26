import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserRole } from './responses/user-role.response';
import { BodyPartDTO } from './models/body-part.dto';
import { EquipmentDTO } from './models/equipment.dto';
import { TargetDTO } from './models/target.dto';

@Injectable({ providedIn: 'root' })
export class DictionariesClient {
  private readonly url = 'dictionaries';

  constructor(private http: HttpClient) {}

  getUserRoles(): Observable<UserRole[]> {
    return this.http.get<UserRole[]>(`${this.url}/user-roles`);
  }

  getBodyParts(): Observable<BodyPartDTO[]> {
    return this.http.get<BodyPartDTO[]>(`${this.url}/body-parts`);
  }

  getEquipments(): Observable<EquipmentDTO[]> {
    return this.http.get<EquipmentDTO[]>(`${this.url}/equipments`);
  }

  getTargets(): Observable<TargetDTO[]> {
    return this.http.get<TargetDTO[]>(`${this.url}/targets`);
  }
}
