import { Subject } from "./subject";
import { EducationTypeGoal } from "./educationTypeGoal";

export class User {
    id?: number;
    username?: string;
    password?: string;
    token?: string;
    refreshToken?: string;
    subjects?: Subject[];
    educationTypesGoals? : EducationTypeGoal[];
}

export class LoginUser {
    username?: string;
    password?: string;
}

export class RegisterUser {
    username?: string;
    password?: string;
}

export class AuthResponse {
    user?: {
        id?: number;
        username?: string;
        token?: string;
    }
}