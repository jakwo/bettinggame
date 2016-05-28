import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'score'
})
export class Score implements PipeTransform {

  transform(value: any, args?: any): any {
    return value !== null ? value : "-";
  }
}
