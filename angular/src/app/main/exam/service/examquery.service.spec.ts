import { TestBed } from '@angular/core/testing';

import { ExamQueryService } from './examquery.service';

describe('ExamQueryService', () => {
  let service: ExamQueryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamQueryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
