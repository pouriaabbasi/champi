export class LeagueMatchModel {
    id: number;
    firstTeamId: number;
    firstTeamName: string;
    secondTeamId: number;
    secondTeamName: string;
    firstTeamScore?: number;
    secondTeamScore?: number;
    winnerTeamId?: number;
    winnerTeamName: string;
    matchDate?: Date;
    matchDatePersian: string;
    editable: boolean;
}
