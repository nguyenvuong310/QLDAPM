import { TestBed } from '@angular/core/testing';

import { ViewExamResolverResolver } from './view-exam-resolver.resolver';

describe('ViewExamResolverResolver', () => {
  let resolver: ViewExamResolverResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(ViewExamResolverResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
