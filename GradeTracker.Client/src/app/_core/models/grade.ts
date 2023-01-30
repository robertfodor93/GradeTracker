import { Subject } from "./subject";

export class Grade {
    id?: number;
    description?: string;
    grade?: number;
    weighting?: number;
    subjectId?: number;
    subject? : Subject;
}