import { TestBed } from '@angular/core/testing';

import { CompetenceAreaService } from './competence-area.service';

describe('CompetenceAreaService', () => {
  let service: CompetenceAreaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompetenceAreaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
