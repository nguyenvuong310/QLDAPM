import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { SubheaderModule } from '@app/shared/common/sub-header/subheader.module';
import { CollapseModule } from 'ngx-bootstrap/collapse'
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ExamRoutingModule } from './exam-routing.module';
import { ExamComponent } from './exam.component';
import { ViewExamModule } from './view-exam/view-exam.module';
import { ExamListComponent } from './exam-list/exam-list.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { DoExamModule } from './do-exam/do-exam.module';

@NgModule({
  declarations: [ExamComponent, ExamListComponent, SearchBarComponent],
  imports: [AppSharedModule, ExamRoutingModule, SubheaderModule, ViewExamModule, PaginationModule, CollapseModule, DoExamModule],
})
export class ExamModule {}