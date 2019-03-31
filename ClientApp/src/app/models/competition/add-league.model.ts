import { AddLeagueTeamModel } from './add-league-team.model';

export class AddLeagueModel {
    competitionStepId: number;
    teamCount: number;
    isHomeAway: boolean;
    peerToPeerPlayCount: number;
    riseTeamCount: number;
    fallTeamCount: number;
    wonPoint: number;
    drawPoint: number;
    lostPoint: number;
    leagueTeams: AddLeagueTeamModel[];
}
