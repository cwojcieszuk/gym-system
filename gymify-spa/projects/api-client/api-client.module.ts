import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';

@NgModule({
  imports: [
    HttpClientModule,
  ],
  exports: [
    HttpClientModule,
  ],
})
export class ApiClientModule {
  static forRoot(): ModuleWithProviders<ApiClientModule> {
    return {
      ngModule: ApiClientModule,
      //add providers
    };
  }
}
