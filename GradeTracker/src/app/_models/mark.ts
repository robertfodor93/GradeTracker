import { Module, IModule } from "./module";

export class Mark {
    id?: number;
    grade?: number;
    weighting?: string;
    module: Module;
    moduleId?: number;
}

export interface IMark {
    id?: number;
    grade?: number;
    weighting?: string;
    module: IModule;
    moduleId?: number;
}