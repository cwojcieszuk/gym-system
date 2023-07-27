import { Component } from '@angular/core';
import { AuthFacade } from '../../auth/+state/auth.facade';

@Component({
  selector: 'gym-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent {
  constructor(
    public facade: AuthFacade
  ) {}
}
