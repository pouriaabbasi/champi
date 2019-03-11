export class CompetitionModel {
    id: number;
    gameTypeId: number;
    name: string;
    gameTypeName: string;
    iteration: number;
    teamCount: number;
    startDate: Date;
    startDatePersian: string;
    endDate?: Date;
    endDatePersian: string;
    isStarted: boolean;
    isCompleted: boolean;
    championTeamId?: number;
    championTeamName: string;
}
