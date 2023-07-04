import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RootTemplateComponent } from './root-template/root-template.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component: RootTemplateComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('./login/login.module').then(m => m.LoginModule),
      },
      {
        path: '',
        pathMatch: 'prefix',
        component: AppComponent,
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
