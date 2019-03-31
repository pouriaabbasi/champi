import { UpdateLeagueTeam } from './update-league-team.model';

export class UpdateLeagueModel {
    teamCount: number;
    isHomeAway: boolean;
    peerToPeerPlayCount: number;
    riseTeamCount: number;
    fallTeamCount: number;
    wonPoint: number;
    drawPoint: number;
    lostPoint: number;
    leagueTeams: UpdateLeagueTeam[];
}
