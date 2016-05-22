import { Component } from '@angular/core';
import { OverviewComponent } from './+overview';
import { Router, RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from '@angular/router-deprecated';
import { StandingsComponent } from './+standings';
import { Auth0Service } from './auth0.service'

@Component({
    moduleId: module.id,
    selector: 'angular2-client-app',
    templateUrl: 'angular2-client.component.html',
    styleUrls: ['angular2-client.component.css'],
    directives: [ROUTER_DIRECTIVES],
    providers: [ROUTER_PROVIDERS, Auth0Service]
})
@RouteConfig([
    { path: '/overview', name: "Overview", component: OverviewComponent, useAsDefault: true },
    { path: '/standings', name: "Standings", component: StandingsComponent }
])
export class Angular2ClientAppComponent {
    constructor(private auth0Service: Auth0Service, private router: Router) {

    }

    ngOnInit() {
    }

    login() {
        this.auth0Service.login().then(() => {
            this.router.renavigate();
        });
    }

    logout() {
        this.auth0Service.logout().then(() => {
            this.router.renavigate();
        });
    }

    loggedIn() {
        return this.auth0Service.loggedIn();
    }
}
