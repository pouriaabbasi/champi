export class LeagueResultModel {
    id: number;
    leagueId: number;
    leagueName: string;
    leagueTeamId: number;
    leagueTeamName: string;
    leagueResultType: number;
    rank: number;
    won: number;
    lost: number;
    draw: number;
    goalsFor: number;
    goalsAgainst: number;
    goalDifference: number;
    played: number;
    points: number;
    previousPosition: number;
}
