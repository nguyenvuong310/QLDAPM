import { TestBed } from '@angular/core/testing';

import { ExamConfigService } from './examconfig.service';

describe('ExamConfigService', () => {
  let service: ExamConfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamConfigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
