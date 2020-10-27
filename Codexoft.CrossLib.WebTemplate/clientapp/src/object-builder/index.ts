import { LoginModel } from '@/data/Models/loginModel'

export class Login implements LoginModel {
    public email!: string;
    public password!: string;
}