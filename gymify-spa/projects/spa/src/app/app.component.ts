import { Component } from '@angular/core';
import { AuthFacade } from './core/auth/+state/auth.facade';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private authFacade: AuthFacade) {
    //authFacade.refresh();
  }
}
