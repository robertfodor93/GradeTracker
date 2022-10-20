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
    marks?: Mark[] | MatTableDataSource<Mark>;
    showOnDashboard?: boolean;
    userId? : string
}

export interface IModule {
  id?: number;
  name?: string;
  competenceArea?: CompetenceArea;
  competenceAreaId? : number
  teacher?: string;
  averageDesiredMark?: number;
  marks?: IMark[] | MatTableDataSource<IMark>;
  showOnDashboard?: boolean;
}
