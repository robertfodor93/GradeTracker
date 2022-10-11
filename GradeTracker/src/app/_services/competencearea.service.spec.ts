import { TestBed } from '@angular/core/testing';

import { CompetenceareaService } from './competencearea.service';

describe('CompetenceareaService', () => {
  let service: CompetenceareaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompetenceareaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
