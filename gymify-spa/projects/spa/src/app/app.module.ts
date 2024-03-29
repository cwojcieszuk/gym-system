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
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { DictionariesStoreModule } from './core/dictionaries-state/dictionaries-store.module';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { ErrorsInterceptor } from './core/auth/interceptors/errors.interceptor';
import { CalendarModule } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { FlatpickrModule } from 'angularx-flatpickr';
import { DateAdapter } from 'angular-calendar';

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
    StoreModule.forRoot({}, {
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true,
        strictStateSerializability: false,    // otherwise Date cannot be used
        strictActionSerializability: false,   // otherwise Date cannot be used
        strictActionWithinNgZone: true,
        strictActionTypeUniqueness: true,
      },
    }),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    ApiClientModule.forRoot(environment.baseApiUrl),
    MatSidenavModule,
    AuthStoreModule,
    LayoutModule,
    MatNativeDateModule,
    DictionariesStoreModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    FlatpickrModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AccessTokenInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorsInterceptor,
      multi: true,
    },
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'outline' },
    },
    {
      provide: MAT_DATE_LOCALE,
      useValue: 'pl-PL',
    },
  ],
  bootstrap: [BootstrapComponent],
})
export class AppModule { }
