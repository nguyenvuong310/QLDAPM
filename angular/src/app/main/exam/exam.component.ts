import { Component, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css'],
  animations: [appModuleAnimation()],
})
export class ExamComponent implements OnInit {

  ngOnInit() {
  }
}