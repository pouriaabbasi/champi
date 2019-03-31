import { LeagueTeamModel } from './league-team.model';

export class LeagueModel {
    id: number;
    competitionStepId: number;
    teamCount: number;
    isHomeAway: boolean;
    peerToPeerPlayCount: number;
    riseTeamCount: number;
    fallTeamCount: number;
    wonPoint: number;
    drawPoint: number;
    lostPoint: number;
    leagueTeams: LeagueTeamModel[];
}
