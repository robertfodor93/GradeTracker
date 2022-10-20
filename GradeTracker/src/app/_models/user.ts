import { Module } from './module';

export class User {
    id?: string;
    username?: string;
    password?: string;
    token?: string;
    refreshToken?: string;
    modules?: Module[]
    role? : string;
}