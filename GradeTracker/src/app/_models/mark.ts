import { Module, IModule } from "./module";

export class Mark {
    id?: number;
    description: string;
    grade?: number;
    weighting?: number;
    moduleId?: number;
}

export interface IMark {
    id?: number;
    grade?: number;
    weighting?: number;
    moduleId?: number;
}