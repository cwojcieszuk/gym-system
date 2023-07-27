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
        // runGuardsAndResolvers: 'always',
        // canActivate: [UnauthenticatedGuard],
      },
      {
        path: '',
        pathMatch: 'prefix',
        component: AppComponent,
        runGuardsAndResolvers: 'always',
        canActivate: [AuthenticatedGuard],
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
