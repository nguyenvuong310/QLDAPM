export class ExamQuery {
    text: string;
    lowerTime: Date;
    upperTime: Date;
    courseId: string;
    examType: string;
    semester: string;
    courseName: string;
    teacher: string;
}

export class Exam {
    courseId: string;
    courseName: string;
    examType: string;
    semester: string;
    teacher: string;
    date: Date;
}