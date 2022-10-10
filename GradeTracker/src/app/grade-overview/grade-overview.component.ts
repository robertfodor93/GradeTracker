import { Component, OnInit, ViewChild, ViewChildren, QueryList, ChangeDetectorRef} from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewGradeComponent } from '../new-grade/new-grade.component';
import { ModuleService } from '../_services/module.service';
import { MarkService } from '../_services/mark.service';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { startWith, switchMap, catchError, map, pipe, of, Observable } from 'rxjs';
import { Module } from '../_models/module';
import { Mark } from '../_models/mark';

@Component({
  selector: 'app-grade-overview',
  templateUrl: './grade-overview.component.html',
  styleUrls: ['./grade-overview.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class GradeOverviewComponent implements OnInit {

  title: string='Notenübersicht';

  dataSource = new MatTableDataSource<Module>()
  dataArray : Module [] = []
  modulesData : Module[] = []
  columnsToDisplay = ['name', 'competenceArea', 'teacher']
  innerDisplayedColumns = ['description','grade', 'weighting', 'date']
  expandedElement: Module | null;

  @ViewChild('outerSort', { static: true }) sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<Mark>>;

  constructor(
    private modulService: ModuleService,
    private gradeservice: MarkService,
    public matDialog: MatDialog, 
    private changeDetectorRef: ChangeDetectorRef) {
      
    }

  ngOnInit() {
    this.modulService.getAll().subscribe(response =>{
      this.dataArray = response
      this.dataArray.forEach(module => {
        if(module.marks && Array.isArray(module.marks) && module.marks.length) {
          this.modulesData = [...this.modulesData, {...module, marks: new MatTableDataSource(module.marks)}]
        } else {
          this.modulesData = [...this.modulesData, module];
        }
      });
      this.dataSource = new MatTableDataSource<Module>(this.modulesData);
      this.dataSource.sort = this.sort
      console.warn(this.dataSource.data)
    })
  }

  subject: string | undefined;
  datum: Date | undefined;
  bez:string | undefined;
  gewichtung:number | undefined;
  note:number | undefined;

  panelOpenState = false;
  
  //Neue Noten erfassen
  openDialog(): void {
    const dialogRef = this.matDialog.open(NewGradeComponent, {
      width: '40%' ,height:'87%', 
      data: {subject: this.subject,datum:this.datum, bez: this.bez, gewictung: this.gewichtung,note:this.note },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.bez = result;
    });
  }

  toggleRow(element: Module) {
    element.marks && (element.marks as MatTableDataSource<Mark>).data?.length?(this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.changeDetectorRef.detectChanges();
    this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<Mark>).sort = this.innerSort.toArray()[index]);
  }
  
}

