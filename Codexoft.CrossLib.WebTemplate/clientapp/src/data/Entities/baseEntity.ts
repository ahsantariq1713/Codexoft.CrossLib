import { BaseValidation } from "./baseValidation";

export interface BaseEntity extends BaseValidation {
    id: string;
    createdAt?: Date;
    updatedAt?: Date;
    isNew: boolean;
}
