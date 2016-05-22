import {Tip} from './tip.model'

export interface Match {
    Id: string,
    Date: Date,
    HomeTeam: string,
    AwayTeam: string,
    HomeTeamFlag: string,
    AwayTeamFlag: string,
    HomeGoals: number,
    AwayGoals: number,
    MatchCompleted: boolean,
    Tips: Tip[]
}