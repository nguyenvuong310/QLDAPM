import { Injectable } from '@angular/core';
import { Exam, ExamQuery } from '../model/examquery';
import { BehaviorSubject } from 'rxjs';
import { ExamListDto, ExamServiceProxy } from '@shared/service-proxies/service-proxies';

@Injectable({
  providedIn: 'root'
})
export class ExamQueryService {
  examQuery: ExamQuery;
  defaultList: ExamListDto[];
  examList: BehaviorSubject<ExamListDto[]> = new BehaviorSubject<ExamListDto[]>([]);
  
  constructor(
    private examService: ExamServiceProxy,
    ) {
    this.clear();
    this.examService.getExams("").subscribe((value) => {
      this.defaultList = value.items;
      this.examList.next(value.items);
    })
  }
  setText(text: string) {
    this.examQuery.text = text;
  }
  setLowerTime(time: Date) {
    this.examQuery.lowerTime = time;
  }
  setUpperTime(time: Date) {
    this.examQuery.upperTime = time;
  }
  setCourseId(id: string) {
    this.examQuery.courseId = id;
  }
  setExamType(type: string) {
    this.examQuery.examType = type;
  }
  setSemester(semester: string) {
    this.examQuery.semester = semester;
  }
  setCourseName(name: string) {
    this.examQuery.courseName = name;
  }
  setTeacher(name: string) {
    this.examQuery.teacher = name;
  }
  clear() {
    this.examQuery = {
      text: null,
      lowerTime: null,
      upperTime: null,
      courseId: null,
      examType: null,
      semester: null,
      courseName: null,
      teacher: null,
    }
  }
  search() {
    this.examList.next(this.defaultList.filter((value) => {
      let b = true;
      if (this.examQuery.text) b = b && (value.course.search(this.examQuery.text) >= 0);
      if (this.examQuery.examType) b = b && (value.exam_type == this.examQuery.examType);
      if (this.examQuery.lowerTime) b = b && (this.examQuery.lowerTime.getTime() - value.start_date.toJSDate().getTime() <= 0)
      if (this.examQuery.upperTime) b = b && (this.examQuery.upperTime.getTime() - value.end_date.toJSDate().getTime() >= 0)
      return b;
    }))
  }
}
