import { QuestionService } from '../../view-exam/service/question.service';
import { Component, OnInit, Input } from '@angular/core';
import { Question } from '../../view-exam/model/question';

@Component({
  selector: 'questions-exam-question',
  templateUrl: './questions-exam.component.html',
  // styleUrls: ['./detail-question.component.css']
})
export class QuestionsExamComponent implements OnInit {

  constructor(
    public questionService: QuestionService,
  ) { }
 
  ngOnInit(): void {
    // this.questionInput.questionType = "Multiple choice";
    
  }
  @Input() id: string;
  @Input() questionInput: Question;
 
  // questionLength = this.questionService.questionList.length;
  typeList = ["Multiple choice", "True/False", "Short answer", "Essay"];
  // showDialog = false;
  // showSuccessDialog = false;
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

  
}


