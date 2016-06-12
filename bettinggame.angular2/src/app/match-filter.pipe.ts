import { Pipe, PipeTransform } from '@angular/core';
import { Match } from './models/match.model'

import * as underscore_ from 'underscore';
const _: UnderscoreStatic = (<any>underscore_)['default'] || underscore_;

import * as moment_ from 'moment';
const moment = (<any>moment_)['default'] || moment_;

@Pipe({
  name: 'matchFilter'
})
export class MatchFilter implements PipeTransform {

  transform(values: Match[], showCompleted: boolean): any {
    if (values && values.length > 0) {
      if (showCompleted === false) {
        return _.filter(values, (value: Match) => moment(value.Date).utc().add(3, 'h') > moment.utc());
      }
    }
    return values;
  }
}
