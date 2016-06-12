import { Component, OnInit } from '@angular/core';
import { CanReuse } from '@angular/router-deprecated';
import { MatchService } from '../match.service'
import { Match } from '../models/match.model';
import { User } from '../models/user.model';
import { Tip } from '../models/tip.model'

import * as underscore_ from 'underscore';
const _: UnderscoreStatic = (<any>underscore_)['default'] || underscore_;

@Component({
  moduleId: module.id,
  selector: 'app-standings',
  templateUrl: 'standings.component.html',
  styleUrls: ['standings.component.css'],
  providers: [
    MatchService
  ]
})
export class StandingsComponent implements OnInit {
  matches: Match[] = [];
  users: User[] = [];

  constructor(private matchService: MatchService) { }

  ngOnInit() {
    this.matchService.GetAll().subscribe((data) => {
      this.initComponent(data);
    }, (error) => console.log(error));
  }

  routerCanReuse() {
    return false;
  }

  private initComponent(matches: Match[]) {
    this.matches = matches;
    this.generateUsers();
    this.calculatePoints();
  }

  private generateUsers() {
    _.each(this.matches, (match) => {
      _.each(match.Tips, (tip: Tip) => {
        if (!_.some(this.users, (user: User) => user.Name === tip.User)) {
          this.users.push({
            Name: tip.User,
            Points: 0
          });
        }
      });
    });
  }

  private calculatePoints() {
    _.each(this.users, user => user.Points = user.Times3 = user.Times2 = user.Times1 = user.Times0 = 0);
    _.each(this.matches, (match) => {
      _.each(this.users, (user: User) => {
        let points = this.matchService.CalculatePoints(match, user.Name);
        switch (points) {
          case 3:
            user.Times3 += 1;
            break;
          case 2:
            user.Times2 += 1;
            break;
          case 1:
            user.Times1 += 1;
            break;
          default:
            user.Times0 += 1;
        }

        user.Points += points;
      });
    });
    this.users = _.chain(this.users).sortBy('Times1').sortBy('Times2').sortBy('Times3').sortBy('Points').reverse().value();
    // this.users = _.sortBy(this.users, (user: User) => user.Points).reverse();
  }
}
