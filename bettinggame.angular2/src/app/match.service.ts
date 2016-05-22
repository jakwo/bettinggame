import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Observable';
import { Match } from './models/match.model';
import { Tip } from './models/tip.model';
import { AuthHttp } from 'angular2-jwt';
import { environment } from './environment'

@Injectable()
export class MatchService {

    private headers: Headers;
    private baseUrl: string = environment.api;

    constructor(private http: Http, private authHttp: AuthHttp) {
        this.setHeaders();
    }

    private setHeaders() {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    public SaveResult(match: Match) {
        this.authHttp.post(`${this.baseUrl}/matches`,
            JSON.stringify(match),
            { headers: this.headers })
            .subscribe(() => { },
            err => console.log(err));
    }

    public SaveTip(tip: Tip) {
        this.authHttp.post(`${this.baseUrl}/matches/tips`,
            JSON.stringify(tip),
            { headers: this.headers })
            .subscribe(() => { },
            err => console.log(err));
    }

    public GetAll = (): Observable<Match[]> => {
        return this.http.get(`${this.baseUrl}/matches/`, { headers: this.headers })
            .map(res => res.json());
    }

    public GetForUser = (userName): Observable<any[]> => {
        return this.authHttp.get(`${this.baseUrl}/matches/${userName}`)
            .map(res => res.json());
    }

    public CalculatePoints(match: Match, user: string) {
        let tip: Tip = _.findWhere(match.Tips, { User: user });

        if (!tip
            || match.HomeGoals === null
            || match.AwayGoals === null
            || tip.HomeGoals === null
            || tip.AwayGoals === null) {
            return 0;
        }

        if (match.HomeGoals === tip.HomeGoals && match.AwayGoals === tip.AwayGoals) {
            return 3;
        }

        if ((match.HomeGoals - match.AwayGoals) === (tip.HomeGoals - tip.AwayGoals)) {
            return 2;
        }

        if (((match.HomeGoals > match.AwayGoals) && (tip.HomeGoals > tip.AwayGoals))
            || ((match.HomeGoals < match.AwayGoals) && (tip.HomeGoals < tip.AwayGoals))) {
            return 1;
        }

        return 0;
    }
}