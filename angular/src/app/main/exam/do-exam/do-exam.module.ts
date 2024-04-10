import { NgModule } from '@angular/core';
import { EditorModule } from 'primeng/editor';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { SubheaderModule } from '@app/shared/common/sub-header/subheader.module';
import { DoExamComponent, FormatTimePipe } from './do-exam.component';
import { QuestionsExamComponent } from './questions-exam/questions-exam.component';
import { EraseDialogComponent } from './erase-dialog/erase-dialog.component';
@NgModule({
  declarations: [DoExamComponent, QuestionsExamComponent, FormatTimePipe , EraseDialogComponent],
  imports: [AppSharedModule, SubheaderModule, EditorModule],
})
export class DoExamModule {}