import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EraseDialogComponent } from './erase-dialog.component';

describe('EraseDialogComponent', () => {
  let component: EraseDialogComponent;
  let fixture: ComponentFixture<EraseDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EraseDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EraseDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
