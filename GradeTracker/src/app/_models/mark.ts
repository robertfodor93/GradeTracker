import { CompetenceArea } from './competenceArea';
import { Module, IModule } from "./module";

export class Mark {
    id?: number;
    description?: string;
    grade?: number;
    weighting?: number;
    moduleId?: number;
    competenceArea?: CompetenceArea
}

export interface IMark {
    id?: number;
    grade?: number;
    weighting?: number;
    moduleId?: number;
}