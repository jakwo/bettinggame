import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tipFilter'
})
export class TipFilter implements PipeTransform {

  transform(value: any[], args?: any): any {
    if (value && value.length > 0 && args === false) {
      return [_.first(value)];
    }
    return value;
  }
}
