import { Injectable } from '@angular/core';
import { Question } from '../model/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  questionList = [];
  exam_id = null;
  constructor() { }
  addQuestion() {
    const id = this.questionList.length + 1;
    const newQuestion: Question = {
      id: id,
      questionType: "Multiple choice",
      questionPoint: 1,
      questionContent: "",
      rightAnswer: "",
      wrongAnswers: []
    }
    this.questionList.push(newQuestion);
  }
  setExamId(id: number) {
    this.exam_id = id;
  }
  getExamId() {
    return this.exam_id;
  }
  deleteQuestion(question: Question) {
    let index = this.questionList.indexOf(question);
    this.questionList.splice(index, 1);
    for (let i = 0; i < this.questionList.length; i++) {
      this.questionList[i].id = i + 1;
    }
  }

  setTypeQuestion(question: Question, type: string) {
    let index = this.questionList.indexOf(question);
    this.questionList[index].questionType = type;
  }
  setPointQuestion(question: Question, point: number) {
    let index = this.questionList.indexOf(question);
    this.questionList[index].questionPoint = point;
  }
  setContentQuestion(question: Question, content: string) {
    let index = this.questionList.indexOf(question);
    this.questionList[index].questionContent = content;
  }
  setRightAnswer(question: Question, answer: string) {
    let index = this.questionList.indexOf(question);
    this.questionList[index].rightAnswer = answer;
  }
  setWrongAnswers(question: Question, answer: string[]) {
    let index = this.questionList.indexOf(question);
    this.questionList[index].wrongAnswers = answer;
  }
  getTypeQuestion(question: Question) {
    let index = this.questionList.indexOf(question);
    return this.questionList[index].questionType;
  }
  getIdQuestion(question: Question) {
    let index = this.questionList.indexOf(question);
    return this.questionList[index].id;
  }
  getPointQuestion(question: Question) { 
    let index = this.questionList.indexOf(question);
    return this.questionList[index].questionPoint;
  }
}
