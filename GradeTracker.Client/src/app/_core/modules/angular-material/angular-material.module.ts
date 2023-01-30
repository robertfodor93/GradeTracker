import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule} from '@angular/material/card';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table'
import { MatTabsModule } from '@angular/material/tabs'
import { MatTableDataSource} from '@angular/material/table';
import { MatRow } from '@angular/material/table';
import { MatHeaderRow } from '@angular/material/table';
import { MatCell } from '@angular/material/table';
import { MatHeaderCell } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import {MatDialogModule} from '@angular/material/dialog';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatDividerModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatTabsModule,
    MatTableDataSource,
    MatRow,
    MatHeaderRow,
    MatCell,
    MatHeaderCell,
    MatToolbarModule,
    MatOptionModule,
    MatSelectModule,
    MatSortModule,
    MatDialogModule
  ]
})
export class AngularMaterialModule { }
