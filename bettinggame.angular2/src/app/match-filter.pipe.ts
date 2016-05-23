import { Pipe, PipeTransform } from '@angular/core';
import { Match } from './models/match.model'

@Pipe({
  name: 'matchFilter'
})
export class MatchFilter implements PipeTransform {

    transform(values: Match[], args?: any): any {
    if (values && values.length > 0 && args === false) {
      return _.filter(values, (value: Match) => value.MatchCompleted === args);
    }
    return values;
  }
}
