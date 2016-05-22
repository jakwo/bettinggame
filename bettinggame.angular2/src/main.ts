import { bootstrap } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { Angular2ClientAppComponent, environment } from './app/';
import { HTTP_PROVIDERS } from '@angular/http';
import { AUTH_PROVIDERS } from 'angular2-jwt';

if (environment.production) {
  enableProdMode();
}

bootstrap(Angular2ClientAppComponent, [
  HTTP_PROVIDERS,
  AUTH_PROVIDERS
]);

