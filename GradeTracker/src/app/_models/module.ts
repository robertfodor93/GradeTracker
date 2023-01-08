import { User } from './user';
import { CompetenceArea } from './competenceArea';
import { MatTableDataSource } from "@angular/material/table";
import { Mark, IMark } from "./mark";

export class Module {
    id?: number;
    name?: string;
    competenceArea?: CompetenceArea;
    competenceAreaId? : number
    teacher?: string;
    averageDesiredMark?: number;
    averageMark? : number;
    marks?: Mark[] | MatTableDataSource<Mark>;
    showOnDashboard?: boolean;
    userId? : number;
}

export interface IModule {
  id?: number;
  name?: string;
  competenceArea?: CompetenceArea;
  competenceAreaId? : number
  teacher?: string;
  averageDesiredMark?: number;
  marks?: IMark[];
  showOnDashboard?: boolean;
}
