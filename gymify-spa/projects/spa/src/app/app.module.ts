import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ApiClientModule } from '../../../api-client/api-client.module';
import { environment } from '../environments/environment';
import { RootTemplateComponent } from './core/root-template/root-template.component';
import { BootstrapComponent } from './core/bootstrap/bootstrap.component';
import { AuthStoreModule } from './core/auth/+state/auth-store.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AccessTokenInterceptor } from './core/auth/interceptors/access-token.interceptor';
import { LayoutModule } from './core/layout/layout.module';

@NgModule({
  declarations: [
    AppComponent,
    RootTemplateComponent,
    BootstrapComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    ApiClientModule.forRoot(environment.baseApiUrl),
    MatSidenavModule,
    AuthStoreModule,
    LayoutModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AccessTokenInterceptor,
      multi: true,
    },
  ],
  bootstrap: [BootstrapComponent],
})
export class AppModule { }
