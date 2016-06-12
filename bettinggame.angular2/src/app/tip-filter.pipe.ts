import { Pipe, PipeTransform } from '@angular/core';

import * as underscore_ from 'underscore';
const _: UnderscoreStatic = (<any>underscore_)['default'] || underscore_;

@Pipe({
  name: 'tipFilter'
})
export class TipFilter implements PipeTransform {

  transform(value: any[], showAll: boolean, completed: boolean, loggedIn: boolean): any[] {
    if (value && value.length > 0) {
      if (loggedIn === true && (showAll === false || completed === false)) {
        return [_.first(value)];
      }

      if (completed === true) {
        return value;
      }
    }
    return [];
  }
}
