import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { QuestionService } from './service/question.service';
import { ExamConfigService } from './service/examconfig.service';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateExamInput, CreateQuestionInput, ExamListDto, ExamServiceProxy, QuestionServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ActivatedRoute, Router } from '@angular/router';


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
      let examConfigData = this.examService.getData();
      let request = new CreateExamInput(examConfigData)
      this.examProxy.addExam(request).subscribe((value) => {
        this.examId = value;
        this.saveQuestions();
      }, (error) => {

      });
    } else {
      this.saveQuestions();
    }
  }

  saveQuestions() {
    let error = false;
    for (let i of this.questionService.questionList) {
      let question = new CreateQuestionInput({
        id: i.id,
        point: i.questionPoint,
        question_type: i.questionType,
        content: i.questionContent,
        answer: i.rightAnswer,
        examId: this.examId
      });
      this.questionProxy.createQuestion(question)
      .subscribe(() => {

      }, error => {
          console.error('There was an error creating the question', error);
          error = true;
      });
    }
    if (!error) {
      this.showSuccessDialog = true;
      setTimeout(() => {
        this.showSuccessDialog = false;
        this.router.navigate(['app/main/exam'])
      }, 3000)
    }
  }

  openModal(message: string) {
    this.modalMessage = message
    this.modalRef = this.modalService.show(this.modalTemplate);
  }
}