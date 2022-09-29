import { TestBed } from '@angular/core/testing';

import { EducationTypeService } from './education-type.service';

describe('EducationTypeService', () => {
  let service: EducationTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EducationTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
