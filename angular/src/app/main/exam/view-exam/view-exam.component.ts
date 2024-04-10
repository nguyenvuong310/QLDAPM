import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { QuestionService } from './service/question.service';
import { ExamConfigService } from './service/examconfig.service';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateExamInput, CreateQuestionInput, ExamListDto, ExamServiceProxy, QuestionServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ActivatedRoute, Router } from '@angular/router';
import { concatMap, delay, finalize } from 'rxjs/operators';
import { forkJoin, from } from 'rxjs';


@Component({
  selector: 'app-view-exam',
  templateUrl: './view-exam.component.html',
  styleUrls: ['./view-exam.component.css'],
  animations: [appModuleAnimation()],
})
export class ViewExamComponent implements OnInit {
  @ViewChild("staticTabs") staticTabs?: TabsetComponent;
  @ViewChild("examConfig") examConfig?: ExamDetailComponent;
  @ViewChild("modalTemplate") modalTemplate?: TemplateRef<void>;

  modalRef?: BsModalRef;
  modalMessage = "Test";

  questionTabDisabled = true;
  examId = null;
  showSuccessDialog = false;
  isLoad = false;
  constructor(
    public questionService: QuestionService,
    public examService: ExamConfigService,
    private modalService: BsModalService,
    private examProxy: ExamServiceProxy,
    private questionProxy: QuestionServiceProxy,
    private router: Router,
    private route: ActivatedRoute
    ) { }

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
  }
  
  enable(e: boolean) {
    this.questionTabDisabled = !e;
  }

   saveConfig() {
    if (this.examId == null) {
      this.isLoad = true;
      console.log("load",this.isLoad);
      let examConfigData = this.examService.getData();
      let request = new CreateExamInput(examConfigData)
      this.examProxy.addExam(request).subscribe(async (value) => {
        this.examId = value;
        
        await this.saveQuestions();
      }, (error) => {

      });
    } else {
      this.saveQuestions();
    }
  }

  async saveQuestions() {
    try {

      await from(this.questionService.questionList).pipe(
        concatMap(i => {
          let question = new CreateQuestionInput({
            id: i.id,
            point: i.questionPoint,
            question_type: i.questionType,
            content: i.questionContent,
            answer: i.rightAnswer,
            examId: this.examId,
            otherAnswer: i.otherAnswers,
            otherAnswer1: i.otherAnswer1s,
            otherAnswer2: i.otherAnswer2s
          });
          return this.questionProxy.createQuestion(question).pipe(delay(1000)); // Adjust delay time as needed (in milliseconds)
        })
      ).toPromise();
    
      // All requests succeeded
      this.isLoad = false;
      this.showSuccessDialog = true;
      setTimeout(() => {
        this.showSuccessDialog = false;
        this.router.navigate(['app/main/exam']);
      }, 3000);
    } catch (error) {
      console.error('An error occurred while creating the questions', error);
    }
  }

  openModal(message: string) {
    this.modalMessage = message
    this.modalRef = this.modalService.show(this.modalTemplate);
  }
}