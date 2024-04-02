import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {DoExamComponent } from './doExam.component';

const routes: Routes = [
    {
        path: '',
        component: DoExamComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DoExamRoutingModule {}
