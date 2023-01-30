import { CompetenceArea } from "./competenceArea";
import { Teacher } from "./teacher";
import { Grade } from "./grade";

export class Subject {
    id?: number;
    name?: string;
    competenceArea?: CompetenceArea;
    competenceAreaId? : number
    teacher?: Teacher;
    averageDesiredMark?: number;
    averageMark? : number;
    Grades?: Grade[];
    showOnDashboard?: boolean;
    userId? : number;
}