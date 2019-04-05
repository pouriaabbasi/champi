import { ChartModel } from './chart.model';

export class StatisticsModel {
    userCount: number;
    teamCount: number;
    gameTypeCount: number;
    leagueCount: number;
    leaguePerMonthData: ChartModel = new ChartModel();
    leagueByLeagueTypeData: ChartModel = new ChartModel();
}
