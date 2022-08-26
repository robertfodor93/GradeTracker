import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSubjectModuleComponent } from './new-subject-module.component';

describe('NewSubjectModuleComponent', () => {
  let component: NewSubjectModuleComponent;
  let fixture: ComponentFixture<NewSubjectModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewSubjectModuleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewSubjectModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
