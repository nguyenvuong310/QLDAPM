import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ExamConfigService } from '../service/examconfig.service';

@Component({
  selector: 'exam-detail-component',
  templateUrl: './exam-detail.component.html',
  styleUrls: ['./exam-detail.component.css']
})
export class ExamDetailComponent implements OnInit {

  courses = ["Quản lí dự án phần mềm", "Nguyên lí ngôn ngữ lập trình", "Lập trính Web"];
  types = ["Giữa kì", "Cuối kì"];
  policies = ["Cao nhất", "Lần nộp cuối cùng", "Trung bình"];

  @Output() validEvent = new EventEmitter<boolean>();
  
  constructor(
    public examService: ExamConfigService,
  ) { }

  ngOnInit(): void {}

  setCourse(e: string) {
    this.examService.course = e;
    this.checkValid();
  }

  setType(e: string) {
    this.examService.examType = e;
    this.checkValid();
  }

  setPolicy(e: string) {
    this.examService.gradingPolicy = e
  }

  checkValid() {
    if (this.examService.course != null && this.examService.examType != null && this.examService.time > 0 && this.examService.startDate != null && this.examService.endDate != null) this.validEvent.emit(true);
    else this.validEvent.emit(false);
  }

}