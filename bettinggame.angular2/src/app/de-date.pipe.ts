import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'deDate'
})
export class DeDate implements PipeTransform {

  transform(value: any, args?: any): any {
    return moment(new Date(value)).locale('de').format('dddd Do MMMM HH:mm');
  }
}
