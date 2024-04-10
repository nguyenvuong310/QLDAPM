import { Exam } from './../model/examquery';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateExamInput, CreateQuestionInput, ExamListDto, ExamServiceProxy, QuestionServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from "../view-exam/service/question.service";
import { ExamConfigService } from '../view-exam/service/examconfig.service';
import { timer, Subscription } from 'rxjs';
import { Pipe, PipeTransform } from '@angular/core';
@Component({
  // selector: 'app-view-exam',
  templateUrl: './do-exam.component.html',
  styleUrls: ['./do-exam.component.css'],
  // animations: [appModuleAnimation()],
})
export class DoExamComponent implements OnInit {

  constructor(
    public questionService: QuestionService,
    public examService: ExamConfigService,
    private router: Router,
    private route: ActivatedRoute
    ) {
      
     }
     examId = null;
     countDown: Subscription;
     counter = null;
     tick = 1000;
     showDialog = false;
  ngOnInit() {
    this.route.data.subscribe(data => {
      let exam: ExamListDto = data["exam"];
      this.questionService.clear();
      for (let question of exam.questions) {
        this.questionService.addQuestion(question);
      }
      this.examService.setData(exam);
      this.questionService.examId = exam.id;
      this.examId = exam.id;
    })
    this.countDownTime();
    console.log("hi",this.questionService.questionList);
    

  }
  countDownTime() {
    this.counter = this.examService.time * 60;
    this.countDown = timer(0, this.tick).subscribe(() => {
      --this.counter;
      if (this.counter <= 0) {
        this.router.navigate(['/app/main/exam']); // Redirect when counter reaches 0
      }
    });
  }
  getNumberArray(length: number): number[] {
    return Array.from(Array(length).keys()).map(x => x + 1);
  }
  openDialog() {
    this.showDialog = true;
  }
  closeDialog() {
    this.showDialog = false;
  }
  saveExam(){
    this.router.navigate(['/app/main/exam']); 
  }
}
@Pipe({
  name: 'formatTime',
})
export class FormatTimePipe implements PipeTransform {
  transform(value: number): string {
    const minutes: number = Math.floor(value / 60);
    const hour: number = Math.floor(minutes / 60);
    const calculatedMinute = minutes - hour * 60;
    return (
      ('00' + hour).slice(-2) +
      ':' +
      ('00' + calculatedMinute).slice(-2) +
      ':' +
      ('00' + Math.floor(value - minutes * 60)).slice(-2)
    );
  }
}