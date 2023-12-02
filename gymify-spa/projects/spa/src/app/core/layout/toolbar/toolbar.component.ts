import { Component, EventEmitter, Output } from '@angular/core';
import { AuthFacade } from '../../auth/+state/auth.facade';
import { map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'gym-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  @Output()
  openMenu = new EventEmitter<void>();

  userFirstName = this.facade.user$.pipe(map(user => user?.name.split(' ')[0]));

  constructor(
    public facade: AuthFacade,
    private router: Router
  ) {}

  navigateToProfile(): void {
    this.router.navigateByUrl('profile');
  }
}
