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

import * as underscore_ from 'underscore';
const _: UnderscoreStatic = (<any>underscore_)['default'] || underscore_;

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
  matchCount: number = 0;
  tipsTipped: number = 0;

  constructor(private matchService: MatchService, private auth0Service: Auth0Service) {
  }

  ngOnInit() {
    this.userName = localStorage.getItem("userName");
    if (this.userName && this.loggedIn()) {
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

  firefoxBlurFix($event) {
    $event.target.focus();
  }

  saveResult(match: Match) {
    if (match.MatchCompleted && this.isAdmin()) {
      if (match.HomeGoals && (match.HomeGoals > 9 || match.HomeGoals < 0)) {
        match.HomeGoals = 0;
      }
      if (match.AwayGoals && (match.AwayGoals > 9 || match.AwayGoals < 0)) {
        match.AwayGoals = 0;
      }
      this.matchService.SaveResult(match);
    }

    this.calculatePoints();
  }

  saveTip(tip: Tip) {
    if (tip.HomeGoals && (tip.HomeGoals > 9 || tip.HomeGoals < 0)) {
      tip.HomeGoals = 0;
    }
    if (tip.AwayGoals && (tip.AwayGoals > 9 || tip.AwayGoals < 0)) {
      tip.AwayGoals = 0;
    }

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
    return this.loggedIn() && tip.User === this.userName;
  }

  matchResultInputAllowed(match: Match) {
    if (this.simulationMode) {
      return !match.MatchCompleted;
    }
    return this.loggedIn() && this.isAdmin() && match.MatchCompleted;
  }

  getPoints(match: Match, user: string) {
    return this.matchService.CalculatePoints(match, user);
  }

  trimUserName(userName: string) {
    if (userName.length >= 8) {
      return `${userName.substring(0, 6)}..`;
    }
    return userName;
  }

  private calculatePoints() {
    this.tipsTipped = 0;
    this.matchCount = _.filter(this.matches, (match) => !match.MatchCompleted).length;

    _.each(this.users, user => user.Points = 0);
    _.each(this.matches, (match) => {
      _.each(this.users, (user: User) => user.Points += this.matchService.CalculatePoints(match, user.Name));
    });
    _.sortBy(this.users, (user: User) => user.Points);
    var loggedInUser = _.findWhere(this.users, { Name: this.userName });

    if (loggedInUser) {

      // Calculate tips given
      _.each(this.matches, (match: Match) => {
        if (!match.MatchCompleted) {
          var tips = _.find(match.Tips, { User: loggedInUser.Name });
          if (tips.AwayGoals != null && tips.HomeGoals != null &&
            tips.AwayGoals >= 0 && tips.HomeGoals >= 0) {
            this.tipsTipped += 1;
          }
        }
      });

      // Move the current user and the tips to the top of the lists. 
      if (_.indexOf(this.users, loggedInUser) != 0) {
        this.users = _.without(this.users, loggedInUser);
        this.users.unshift(loggedInUser);

        _.each(this.matches, (match: Match) => {
          var tips = _.find(match.Tips, { User: loggedInUser.Name });

          match.Tips = _.without(match.Tips, tips);
          match.Tips.unshift(tips);
        });
      }
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