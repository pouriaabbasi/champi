import { UpdateLeagueTeam } from './update-league-team.model';

export class UpdateLeagueModel {
    teamCount: number;
    isHomeAway: boolean;
    peerToPeerPlayCount: number;
    riseTeamCount: number;
    fallTeamCount: number;
    leagueTeams: UpdateLeagueTeam[];
}
