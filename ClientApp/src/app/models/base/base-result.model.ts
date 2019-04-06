export class BaseResultModel<T> {
    type: number;
    message: string;
    data: T;
}
