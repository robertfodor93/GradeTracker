import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectModuleOverviewComponent } from './subject-module-overview.component';

describe('SubjectModuleOverviewComponent', () => {
  let component: SubjectModuleOverviewComponent;
  let fixture: ComponentFixture<SubjectModuleOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjectModuleOverviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubjectModuleOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
