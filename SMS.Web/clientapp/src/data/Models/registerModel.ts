import { BaseValidation } from "./../Entities/baseValidation";

export interface RegisterModel extends BaseValidation {
    name: string;
    email: string;
    password: string;
}
