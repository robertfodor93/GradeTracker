import { User } from './user';
import { CompetenceArea } from './competenceArea';
import { MatTableDataSource } from "@angular/material/table";
import { Mark, IMark } from "./mark";
import { Teacher } from './teacher';

export class Module {
    id?: number;
    name?: string;
    competenceArea?: CompetenceArea;
    competenceAreaId? : number
    teacher?: Teacher;
    averageDesiredMark?: number;
    averageMark? : number;
    marks?: Mark[] | MatTableDataSource<Mark>;
    showOnDashboard?: boolean;
    userId? : number;
    isEditable? : boolean
}

export const ModuleColumns = [
  {
    key: 'name',
    type: 'text',
    label: 'Modul',
    required: true
  },
  {
    key: 'educationTypeId',
    type: 'number',
    label: 'Bildungstyp',
    required: true,
  },
  {
    key: 'competenceAreaId',
    type: 'number',
    label: 'Fachtyp',
    required: true,
  },
  {
    key: 'teacher',
    type: 'Teacher',
    label: 'Lehrer'
  },
  {
    key: 'isEditable',
    type: 'isEditable',
    label: ''
  }
]

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