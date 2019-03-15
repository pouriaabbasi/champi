export class CompetitionStepModel {
    id: number;
    competitionId: number;
    step: number;
    competitionType: number;
    competitionTypeString?: string;
    startDate?: Date;
    startDatePersian: string;
    endDate?: Date;
    endDatePersian: string;
    isStarted: boolean;
    isCompleted: boolean;
}

