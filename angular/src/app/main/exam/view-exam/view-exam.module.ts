import { NgModule } from '@angular/core';
import { ViewExamRoutingModule } from './view-exam-routing.module';
import { ViewExamComponent } from './view-exam.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { EditorModule } from 'primeng/editor';
import { DetailQuestionComponent } from './detail-question/detail-question.component';
import { ExamDetailComponent } from './exam-detail/exam-detail.component';
import { EraseDialogComponent } from './detail-question/erase-dialog/erase-dialog.component';
import { SuccessDialogComponent } from './detail-question/success-dialog/success-dialog.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { SubheaderModule } from '@app/shared/common/sub-header/subheader.module';

@NgModule({
  declarations: [ViewExamComponent, FileUploadComponent, ExamDetailComponent, DetailQuestionComponent, EraseDialogComponent, SuccessDialogComponent],
  imports: [AppSharedModule, SubheaderModule, ViewExamRoutingModule, EditorModule],
})
export class ViewExamModule {}
