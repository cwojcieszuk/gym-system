import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { BASE_URL } from './src/lib/config/base-url.token';
import { ApiInterceptor } from './src/lib/interceptors/api.interceptor';

@NgModule({
  imports: [
    HttpClientModule,
  ],
  exports: [
    HttpClientModule,
  ],
})
export class ApiClientModule {
  static forRoot(baseUrl: string): ModuleWithProviders<ApiClientModule> {
    return {
      ngModule: ApiClientModule,
      providers: [
        { provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true },
        { provide: BASE_URL, useValue: baseUrl },
      ],
    };
  }
}
