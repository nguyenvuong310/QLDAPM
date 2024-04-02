import { Injectable } from '@angular/core';
import { Exam, ExamQuery } from '../model/examquery';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExamQueryService {
  examQuery: ExamQuery
  examList: BehaviorSubject<Exam[]> = new BehaviorSubject<Exam[]>([
    { courseId: 'CO3005', courseName: 'Nguyên lý ngôn ngữ lập trình', examType: 'Giữa kỳ', semester: '232', teacher: 'Nguyễn Văn A', date: new Date('2021-10-10 7:30') },
    { courseId: 'CO3006', courseName: 'Cấu trúc dữ liệu và giải thuật', examType: 'Cuối kỳ', semester: '232', teacher: 'Nguyễn Văn B', date: new Date('2021-10-10 7:30') },
    { courseId: 'CO3007', courseName: 'Lập trình hướng đối tượng', examType: 'Giữa kỳ', semester: '232', teacher: 'Nguyễn Văn C', date: new Date('2021-10-10 7:30') },
    { courseId: 'CO3008', courseName: 'Cơ sở dữ liệu', examType: 'Cuối kỳ', semester: '232', teacher: 'Nguyễn Văn D', date: new Date('2021-10-10 7:30') },
    { courseId: 'CO3009', courseName: 'Mạng máy tính', examType: 'Giữa kỳ', semester: '232', teacher: 'Nguyễn Văn E', date: new Date('2021-10-10 7:30') },
  ]);
  
  constructor() {
    this.clear();
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
    this.examList.next([...this.examList.value, { courseId: 'CO3009', courseName: 'Mạng máy tính', examType: 'Giữa kỳ', semester: '232', teacher: 'Nguyễn Văn E', date: new Date() }])
  }
}
