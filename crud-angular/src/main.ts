import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { tokenHttpInterceptor } from './app/token-http-interceptor';
import { provideAnimations } from '@angular/platform-browser/animations';
import { importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { ToastrModule } from 'ngx-toastr';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(withInterceptors([tokenHttpInterceptor])),
    provideRouter(routes),
    provideAnimations(),
    importProvidersFrom(ToastrModule.forRoot())
  ],
}).catch((err) => console.error(err));
