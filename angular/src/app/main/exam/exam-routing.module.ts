import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { ExamComponent } from './exam.component';
import { ViewExamComponent } from './view-exam/view-exam.component';

const routes: Routes = [
    {
        path: '',
        component: ExamComponent,
        pathMatch: 'full'
    },
    {
        path: 'view-exam',
        component: ViewExamComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ExamRoutingModule {}