import { TestBed } from '@angular/core/testing';

import { EducationTypeGoalService } from './education-type-goal.service';

describe('EducationTypeGoalService', () => {
  let service: EducationTypeGoalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EducationTypeGoalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
