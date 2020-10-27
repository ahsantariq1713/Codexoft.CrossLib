import { BaseDto } from "./baseDto";

export interface UserDto extends BaseDto {
    email: string;
    name: string;
    role: string;
}
