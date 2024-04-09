import { Exam } from './../model/examquery';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateExamInput, CreateQuestionInput, ExamListDto, ExamServiceProxy, QuestionServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from "../view-exam/service/question.service";
import { ExamConfigService } from '../view-exam/service/examconfig.service';

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
    console.log("hi",this.questionService.questionList);
  }
  getNumberArray(length: number): number[] {
    return Array.from(Array(length).keys()).map(x => x + 1);
  }

}