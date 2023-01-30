import { Subject } from "./subject"
import { EducationType } from "./educationType"

export class CompetenceArea {
    id?: number;
    name?: string;
    weighting?: number;
    subjects?: Subject[];
    educationTypeId?: number;
    educationType?: EducationType;
}