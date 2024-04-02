import { NgModule } from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { DoExamRoutingModule } from './doExam-routing.module';
import { DoExamComponent } from './doExam.component';
import { CustomizableDashboardModule } from '@app/shared/common/customizable-dashboard/customizable-dashboard.module';
import { ExamModule } from '../exam/exam.module';
@NgModule({
    declarations: [DoExamComponent],
    imports: [AppSharedModule, AdminSharedModule, DoExamRoutingModule, CustomizableDashboardModule, ExamModule],
})
export class DoExamModule {}
