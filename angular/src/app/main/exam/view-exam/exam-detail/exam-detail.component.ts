import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CreateExamInput, ExamServiceProxy } from '@shared/service-proxies/service-proxies';
import { QuestionService } from '../service/question.service';

@Component({
  selector: 'exam-detail-component',
  templateUrl: './exam-detail.component.html',
  styleUrls: ['./exam-detail.component.css']
})
export class ExamDetailComponent implements OnInit {

  subjects = [
  {id: 1, name: "Quản lí dự án phần mềm"},
  {id: 2, name: "Nguyên lí ngôn ngữ lập trình"},
  {id: 3, name: "Lập trính Web"},
  ];

  type = ["Giữa kì", "Cuối kì"];

  policies = ["Cao nhất", "Lần nộp cuối cùng", "Trung bình"];

  @Output() validEvent = new EventEmitter<boolean>();
  id = null;
  selectedSubject = null;
  selectedType = null;
  startDate = null;
  endDate = null;
  time = 0;
  isRandom = false;
  multipleAttempt = false;
  attemptCount = 0;
  selectedPolicy = this.policies[2];
  allowMistakeReview = false;
  allowMistakeReviewLast = false;
  allowMistakeReviewAll = false;
  allowCorrectReview = false;
  allowCorrectReviewLast = false;
  oncePerQuestion = false
  requirePassword = false
  password = ""
  
  constructor(
    private _examService: ExamServiceProxy,
    public questionService: QuestionService
    ) { 
  }

  ngOnInit(): void {
    this.id = Math.floor(Math.random() * 1000000000);
  }

  setSubject(e: any) {
    this.selectedSubject = e;
    this.checkValid();
  }

  setType(e: any) {
    this.selectedType = e;
    this.checkValid();
  }

  setPolicy(e: any) {
    this.selectedPolicy = e
  }

  checkValid() {
    if (this.selectedSubject != null && this.selectedType != null && this.time > 0 && this.startDate != null && this.endDate != null) this.validEvent.emit(true);
    else this.validEvent.emit(false);
  }

  post() {
    let ids = Math.floor(Math.random() * 1000000000)
    this.id = ids;
    this.questionService.setExamId(ids);
    let request = new CreateExamInput({
      "id": this.id,
      "working_time": this.time,
      "mix_question": this.isRandom,
      "redo_num": this.attemptCount,
      "point_is_cal": this.selectedPolicy,
      "review_wrong_ans": this.allowMistakeReview,
      "review_right_ans": this.allowCorrectReview,
      "view_question_one": this.oncePerQuestion,
      "require_password": this.password,
      "start_date": this.startDate,
      "end_date": this.endDate,
      "exam_type": this.selectedType,
      "course": this.selectedSubject.name
    })
    this._examService.addExam(request).subscribe();
    return this.id;
  }
}