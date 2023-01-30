import { User } from "./user"
import { EducationType } from "./educationType"

export class EducationTypeGoal {
    id?: number;
    averageDesiredMark?: number;
    userId? : number;
    user?: User;
    educationTypeId?: number;
    educationType?: EducationType;
}