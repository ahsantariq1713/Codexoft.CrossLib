import { BaseEntity } from "./baseEntity";

export interface User extends BaseEntity {
    name: string;
    email: string;
    hashPassword: string;
    role: string;
}
