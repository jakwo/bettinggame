import { Pipe, PipeTransform } from '@angular/core';

import * as underscore_ from 'underscore';
const _: UnderscoreStatic = (<any>underscore_)['default'] || underscore_;

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
