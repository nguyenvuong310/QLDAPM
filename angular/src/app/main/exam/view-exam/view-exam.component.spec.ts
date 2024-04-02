import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ViewExamComponent } from './view-exam.component';

describe('ViewExamComponent', () => {
  let component: ViewExamComponent;
  let fixture: ComponentFixture<ViewExamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewExamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
