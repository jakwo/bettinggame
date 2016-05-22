import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { AuthHttp, tokenNotExpired } from 'angular2-jwt';
import { environment } from './environment'

// Avoid name not found warnings
declare var Auth0Lock: any;

@Injectable()
export class Auth0Service {

    lock = new Auth0Lock(environment.auth0client, environment.auth0url);

    constructor(private authHttp: AuthHttp) { }

    login() {
        return new Promise((resolve, reject) => {
            this.lock.show({dict: 'de'}, (err, profile: any, token) => {

                if (err) {
                    reject();
                    return;
                }

                localStorage.setItem('userName', profile.nickname);
                localStorage.setItem('role', profile.roles[0]);
                localStorage.setItem('id_token', token);
                resolve();
            });
        });
    }

    isAdmin() {
        return localStorage.getItem("role") && localStorage.getItem("role") === 'admin';
    }

    logout() {
        return new Promise((resolve, reject) => {
            localStorage.removeItem('userName');
            localStorage.removeItem('role');
            localStorage.removeItem('id_token');
            resolve();
        });
    }

    loggedIn() {
        return tokenNotExpired();
    }
}
