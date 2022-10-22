import { EducationTypeGoal } from './educationTypeGoal';
import { Module } from './module';

export class User {
    id?: number;
    username?: string;
    password?: string;
    token?: string;
    refreshToken?: string;
    modules?: Module[]
    educationTypesGoals? : EducationTypeGoal[]
}