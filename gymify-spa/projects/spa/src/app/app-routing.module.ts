import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RootTemplateComponent } from './core/root-template/root-template.component';
import { AppComponent } from './app.component';
import { AuthenticatedGuard } from './core/auth/guards/authenticated.guard';
import { UnauthenticatedGuard } from './core/auth/guards/unauthenticated.guard';

const routes: Routes = [
  {
    path: '',
    component: RootTemplateComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('./core/login/login.module').then(m => m.LoginModule),
        canActivate: [UnauthenticatedGuard],
      },
      {
        path: '',
        pathMatch: 'prefix',
        component: AppComponent,
        runGuardsAndResolvers: 'always',
        canActivate: [AuthenticatedGuard],
        children: [
          {
            path: 'users',
            loadChildren: () => import('./modules/users/users.module').then(m => m.UsersModule),
          },
          {
            path: 'profile',
            loadChildren: () => import('./modules/profile/profile.module').then(m => m.ProfileModule),
          },
          {
            path: 'exercises',
            loadChildren: () => import('./modules/exercises/exercises.module').then(m => m.ExercisesModule),
          },
          {
            path: 'personal-templates',
            loadChildren: () => import('./modules/templates/templates.module').then(m => m.TemplatesModule),
            data: {
              isCommunity: false,
            },
          },
          {
            path: 'community-templates',
            loadChildren: () => import('./modules/templates/templates.module').then(m => m.TemplatesModule),
            data: {
              isCommunity: true,
            },
          },
          {
            path: 'trainings',
            loadChildren: () => import('./modules/trainings/trainings.module').then(m => m.TrainingsModule),
          },
          {
            path: 'coaches',
            loadChildren: () => import('./modules/coaches/coaches.module').then(m => m.CoachesModule),
          },
          {
            path: 'group-sessions',
            loadChildren: () => import('./modules/group-sessions/group-sessions.module').then(m => m.GroupSessionsModule),
          },
          {
            path: 'calendar',
            loadChildren: () => import('./modules/calendar/calendar.module').then(m => m.CalendarModule),
          },
        ],
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
