import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

export interface Subject {
  subject: string;
  fachtyp: string;
  kompetenzbereich: string;
  teacher: string;
  durchschnitt: number;
  anzahlNoten: number;
  favorit: boolean;
}

const SUBJECT_DATA_EFZ: Subject[] = [
  { subject: 'M117', fachtyp: 'EFZ', kompetenzbereich: 'Informatikkompetenzen', teacher: 'Erik Benz', durchschnitt: 4, anzahlNoten: 3, favorit: false },
  { subject: 'M200', fachtyp: 'EFZ', kompetenzbereich: 'ÜK', teacher: 'Erik Benz', durchschnitt: 3, anzahlNoten: 2, favorit: true },
  { subject: 'M300', fachtyp: 'EFZ', kompetenzbereich: 'Informatikkompetenzen', teacher: 'Erik Benz', durchschnitt: 6, anzahlNoten: 7, favorit: true },
  { subject: 'M400', fachtyp: 'EFZ', kompetenzbereich: 'ÜK', teacher: 'Erik Benz', durchschnitt: 5, anzahlNoten: 1, favorit: false }
];

const SUBJECT_DATA_BM: Subject[] = [
  { subject: 'Mathe', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Heinz Estermann', durchschnitt: 5, anzahlNoten: 2, favorit: true },
  { subject: 'Deutsch', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Peter Wicki', durchschnitt: 5, anzahlNoten: 2, favorit: false },
  { subject: 'Englisch', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Timothy Black', durchschnitt: 4.5, anzahlNoten: 6, favorit: false },
  { subject: 'Wirtschaft', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Patrick Stark', durchschnitt: 5.5, anzahlNoten: 4, favorit: true }
];


@Component({
  selector: 'app-subject-module-overview',
  templateUrl: './subject-module-overview.component.html',
  styleUrls: ['./subject-module-overview.component.scss']
})




export class SubjectModuleOverviewComponent implements AfterViewInit {

  displayedColumns = ['subject', 'fachtyp', 'kompetenzbereich', 'teacher', 'durchschnitt', 'anzahlNoten', 'favorit'];

  dataSourceEFZ = new MatTableDataSource (SUBJECT_DATA_EFZ);
  dataSourceBM = new MatTableDataSource (SUBJECT_DATA_BM);

  title = "Fach-/Modulübersicht";

  constructor(private _liveAnnouncer: LiveAnnouncer) {}

  @ViewChild(MatSort, { static: false }) sort!: MatSort;


  ngAfterViewInit() {
    this.dataSourceBM.sort = this.sort;
    this.dataSourceEFZ.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}





