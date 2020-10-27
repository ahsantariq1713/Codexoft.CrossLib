import { BaseValidation } from "./../Entities/baseValidation";

export interface LoginModel extends BaseValidation {
    email: string;
    password: string;
}
