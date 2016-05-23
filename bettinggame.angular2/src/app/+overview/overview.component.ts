import { Component, OnInit } from '@angular/core';
import { CanReuse } from '@angular/router-deprecated';
import { MatchService } from '../match.service'
import { Auth0Service } from '../auth0.service'
import { Match } from '../models/match.model';
import { User } from '../models/user.model';
import { Tip } from '../models/tip.model'
import { Score } from  '../score.pipe'
import { TipFilter } from  '../tip-filter.pipe'
import { MatchFilter } from  '../match-filter.pipe'
import { DeDate } from  '../de-date.pipe'

@Component({
  moduleId: module.id,
  selector: 'app-overview',
  templateUrl: 'overview.component.html',
  styleUrls: ['overview.component.css'],
  pipes: [Score, TipFilter, MatchFilter, DeDate],
  providers: [
    MatchService
  ]
})
export class OverviewComponent implements OnInit {
  showAllTips: boolean = false;
  simulationMode: boolean = false;
  showCompleted: boolean = true;
  matches: Match[] = [];
  users: User[] = [];
  userName: string;

  constructor(private matchService: MatchService, private auth0Service: Auth0Service) {
  }

  ngOnInit() {
    this.userName = localStorage.getItem("userName");
    if (this.userName) {
      this.matchService.GetForUser(this.userName).subscribe((data) =>
        this.initComponent(data),
        (error) => console.log(error));
    } else {
      this.showAllTips = true;
      this.matchService.GetAll().subscribe((data) =>
        this.initComponent(data),
        (error) => console.log(error));
    }
  }

  routerCanReuse() {
    return false;
  }

  saveResult(match: Match) {
    if (match.MatchCompleted && this.isAdmin()) {
      this.matchService.SaveResult(match);
    }
    this.calculatePoints();
  }

  saveTip(tip: Tip) {
    this.matchService.SaveTip(tip);
    this.calculatePoints();
  }

  getUserPoints(user: string) {
    return _.findWhere(this.users, { Name: user }).Points;
  }

  loggedIn() {
    return this.auth0Service.loggedIn();
  }

  isAdmin() {
    return this.loggedIn() && this.auth0Service.isAdmin();
  }

  tipInputAllowed(match: Match, tip: Tip) {
    if (match.MatchCompleted || tip.User !== this.userName) {
      return false;
    }
    return tip.User === this.userName;
  }

  matchResultInputAllowed(match: Match) {
    if (this.simulationMode) {
      return !match.MatchCompleted;
    }
    return this.isAdmin() && match.MatchCompleted;
  }

  getPoints(match: Match, user: string) {
    return this.matchService.CalculatePoints(match, user);
  }

  private calculatePoints() {
    _.each(this.users, user => user.Points = 0);
    _.each(this.matches, (match) => {
      _.each(this.users, (user: User) => user.Points += this.matchService.CalculatePoints(match, user.Name));
    });
    _.sortBy(this.users, (user: User) => user.Points);
    var loggedInUser = _.findWhere(this.users, { Name: this.userName });

    if (loggedInUser && _.indexOf(this.users, loggedInUser) != 0) {
      this.users = _.without(this.users, loggedInUser);
      this.users.unshift(loggedInUser);

      _.each(this.matches, (match: Match) => {
        var tips = _.find(match.Tips, { User: loggedInUser.Name });

        match.Tips = _.without(match.Tips, tips);
        match.Tips.unshift(tips);
      });
    }
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
}