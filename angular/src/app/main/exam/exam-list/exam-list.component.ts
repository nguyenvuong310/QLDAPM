import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ExamQueryService } from '../service/examquery.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html',
  styleUrls: ['./exam-list.component.css']
})
export class ExamListComponent implements OnInit {
  totalItems = 0;

  constructor(
    public examQueryService: ExamQueryService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.totalItems = this.examQueryService.examList.value.length;
    this.examQueryService.examList.subscribe((value) => {
      this.updatePagedTests();
    })
  }
  
  currentPage = 1;
  itemsPerPage = 10;
  pagedTests = [];

  updatePagedTests() {
    const itemsPerPage = Number(this.itemsPerPage);
    const start = (this.currentPage - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    this.pagedTests = this.examQueryService.examList.value.slice(start, end);
    this.totalItems = this.examQueryService.examList.value.length;
  }
  pageChanged(event: PageChangedEvent): void {
    this.currentPage = event.page;
    this.updatePagedTests();
  }
  viewExam(id: number) {
    this.router.navigate(['view-exam/' + id], {relativeTo: this.route});
  }
  doExam(id: number) {
    this.router.navigate(['do-exam/' + id], {relativeTo: this.route});
  }

  ngOnInit(): void {
    this.updatePagedTests();
  }

}
