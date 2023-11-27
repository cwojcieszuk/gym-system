import { Component, Input } from '@angular/core';

@Component({
  selector: 'gym-dashboard-card',
  templateUrl: './dashboard-card.component.html',
  styleUrls: ['./dashboard-card.component.scss'],
})
export class DashboardCardComponent {
  @Input()
  header?: string;

  @Input()
  subtitle?: string;

  @Input()
  redirectUrl?: string;

  @Input()
  isLoading: boolean | null = false;
}
