export class UpdateCompetitionModel {
    gameTypeId: number;
    name: string;
    startDate: Date;
    endDate?: Date;
    isStarted: boolean;
    isCompleted: boolean;
}
