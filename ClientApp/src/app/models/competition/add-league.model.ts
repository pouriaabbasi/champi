import { AddLeagueTeamModel } from './add-league-team.model';

export class AddLeagueModel {
    competitionStepId: number;
    teamCount: number;
    isHomeAway: boolean;
    peerToPeerPlayCount: number;
    riseTeamCount: number;
    fallTeamCount: number;
    leagueTeams: AddLeagueTeamModel[];
}
