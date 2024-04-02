import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    templateUrl: './doExam.component.html',
    styleUrls: ['./doExam.component.css'],
    encapsulation: ViewEncapsulation.None,
})
export class DoExamComponent extends AppComponentBase {


    constructor(injector: Injector) {
        super(injector);
    }
}
