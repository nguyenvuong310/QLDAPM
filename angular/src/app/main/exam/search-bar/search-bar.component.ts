import { Component, OnInit } from '@angular/core';
import { ExamQueryService } from '../service/examquery.service';

@Component({
  selector: 'exam-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  isCollapsed = true

  searchText = null;
  lowerTime = null;
  upperTime = null;
  courseId = null;
  courseName = null;
  teacher = null;
  examType = null;
  semester = null;

  type = ["Giữa kì", "Cuối kì"];
  semesterList = ["HK231", "HK232", "HK233", "HK241"];

  constructor(
    public examQueryService: ExamQueryService
  ) { }

  ngOnInit(): void {
  }

  setType(item: string) {
    this.examType = item;
  }

  setSemester(sem: string) {
    this.semester = sem;
  }

  clear() {
    this.searchText = null;
    this.lowerTime = null;
    this.upperTime = null;
    this.courseId = null;
    this.courseName = null;
    this.teacher = null;
    this.examType = null;
    this.semester = null;
    this.examQueryService.clear();
  }

  onTextChange(e: string) {
    this.examQueryService.setText(e);
    this.examQueryService.search();
  }

  search() {
    this.examQueryService.setText(this.searchText);
    this.examQueryService.setLowerTime(this.lowerTime);
    this.examQueryService.setUpperTime(this.upperTime);
    this.examQueryService.setCourseId(this.courseId);
    this.examQueryService.setExamType(this.examType);
    this.examQueryService.setSemester(this.semester);
    this.examQueryService.setCourseName(this.courseName);
    this.examQueryService.setTeacher(this.teacher);
    this.examQueryService.search();
  }
}
