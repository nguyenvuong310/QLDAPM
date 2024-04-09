import { Component, OnInit, Input } from '@angular/core';
import { QuestionService } from '../service/question.service';
import { Question } from '../model/question';

@Component({
  selector: 'app-detail-question',
  templateUrl: './detail-question.component.html',
  styleUrls: ['./detail-question.component.css']
})
export class DetailQuestionComponent implements OnInit {

  constructor(
    public questionService: QuestionService,
  ) { }

  ngOnInit(): void {
    this.questionInput.questionType = "Multiple choice";
  }
  @Input() id: string;
  @Input() questionInput: Question;
  // questionLength = this.questionService.questionList.length;
  typeList = ["Multiple choice", "True/False", "Short answer", "Essay"];
  showDialog = false;
  showSuccessDialog = false;
  wrongAnswers: string[] = [];

  setQuestionType(type: string) {
    this.wrongAnswers = [];
    this.questionInput.questionContent = "";
    this.questionInput.questionType = type;
  }
  setQuestionPoint(point: number) {
    this.questionInput.questionPoint = point;
  }
  setWrongAnswers(answer: string) {
    this.wrongAnswers.push(answer);
  }
  deleteQuestion() {
    this.questionService.deleteQuestion(this.questionInput);
    this.showDialog = false;
  }
  openDialog() {
    this.showDialog = true;
  }
  closeDialog() {
    this.showDialog = false;
  }

  checkValidData () {
    if (this.questionInput.questionType === 'Multiple choice') {
      return (this.questionInput.questionContent && this.questionInput.rightAnswer && this.wrongAnswers.length === 3 && this.questionInput.questionPoint)
    }
    if (this.questionInput.questionType === 'True/False') {
      return (this.questionInput.questionContent && this.questionInput.rightAnswer && this.wrongAnswers.length >= 1 && this.questionInput.questionPoint)
    }
    else {
      return this.questionInput.questionContent && this.questionInput.questionPoint;
    }
  }
}
