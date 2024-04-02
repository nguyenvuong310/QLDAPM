import { Component, OnInit, Input } from '@angular/core';
import { QuestionService } from '../service/question.service';
import { Question } from '../model/question';
import { CreateQuestionInput, QuestionServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-detail-question',
  templateUrl: './detail-question.component.html',
  styleUrls: ['./detail-question.component.css']
})
export class DetailQuestionComponent implements OnInit {

  constructor(
    public questionService: QuestionService,
    private _questionServiceTest: QuestionServiceProxy  
  ) { }

  ngOnInit(): void {
  }
  @Input() id: string;
  @Input() questionInput: Question;
  // questionLength = this.questionService.questionList.length;
  typeList = ["Multiple choice", "True/False", "Short answer", "Essay"];
  questionType: string = "Multiple choice";
  showDialog = false;
  showSuccessDialog = false;
  questionPoint: number = 1;
  questionContent: string = "";
  rightAnswer: string = "";
  wrongAnswers: string[] = [];
  isProssibleDeleted = false;
  setQuestionType(type: string) {
    this.questionContent = "";
    this.wrongAnswers = [];
    this.questionType = type;
  }
  setQuestionPoint(point: number) {
    this.questionPoint = point;
  }
  setWrongAnswers(answer: string) {
    this.wrongAnswers.push(answer);
  }
  openDialog() {
    this.showDialog = true;
  }
  deleteQuestion() {
    this.questionService.deleteQuestion(this.questionInput);
    this.showDialog = false;
  }
  closeDialog() {
    this.showDialog = false;
  }
  // questionTest = new CreateQuestionInput({
  //   content: this.questionContent,
  //   answer: this.rightAnswer
  // })
  checkValidData () {
    if (this.questionType === 'Multiple choice') {
      return (this.questionContent && this.rightAnswer && this.wrongAnswers.length === 3 && this.questionPoint)
    }
    if (this.questionType === 'True/False') {
      return (this.questionContent && this.rightAnswer && this.wrongAnswers.length >= 1 && this.questionPoint)
    }
    else {
      return this.questionContent && this.questionPoint;
    }
  }
    setData() {
      let mockData = new CreateQuestionInput({
        point: this.questionPoint,
        question_type: this.questionType,
        content: this.questionContent,
        answer: this.rightAnswer,
        examId: this.questionService.getExamId()
      });
      this.isProssibleDeleted = true
      this._questionServiceTest.createQuestion(mockData)
      .subscribe(() => {
          this.showSuccessDialog = true;
          setTimeout(() => {
            this.showSuccessDialog = false;
          }, 2000);
      }, error => {
          console.error('There was an error creating the question', error);
      });
  }
}
