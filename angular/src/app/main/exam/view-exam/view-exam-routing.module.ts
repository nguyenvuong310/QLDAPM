import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ViewExamComponent} from './view-exam.component';

const routes: Routes = [{
    path: '',
    component: ViewExamComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ViewExamRoutingModule {}