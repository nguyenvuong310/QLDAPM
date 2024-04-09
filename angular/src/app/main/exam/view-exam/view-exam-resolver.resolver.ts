import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { ExamListDto, ExamServiceProxy } from '@shared/service-proxies/service-proxies';
import { Observable, from } from 'rxjs';
import { concatMap, first, pluck } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ViewExamResolverResolver implements Resolve<ExamListDto> {
  constructor (
    private examProxy: ExamServiceProxy,
  ) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ExamListDto> {
    const id = route.paramMap.get('id')!;
    return this.examProxy.getExams("")
    .pipe(pluck("items"))
    .pipe(concatMap(value => value))
    .pipe(first<ExamListDto, null>((value) => value.id.toString() == id))
  }
}
