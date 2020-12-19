import { BaseForm } from '../_models/base-form.model';

import { ios } from 'tns-core-modules/application';

declare var NSDateFormatter: any;
declare var java: any;

export abstract class BaseFormHelper<
  TFormSource extends BaseForm<TFormSource>
> {
  constructor() {}

  reloadFormSource(formSource: TFormSource, newValues: any): TFormSource {
    if (newValues) {
      const clonedFormSource = formSource.clone();
      for (const propName in newValues) {
        if (newValues.hasOwnProperty(propName)) {
          clonedFormSource[propName] = newValues[propName];
        }
      }
      return clonedFormSource;
    }
  }

  // Unfortunately, date control offerred by RadDataForm does not support
  // Date Formatting so this is a native way to format date.
  protected changeDateFormatting(editor: any) {
    if (ios) {
      const dateFormatter = NSDateFormatter.alloc().init();
      dateFormatter.dateFormat = 'MM/dd/yyyy';
      editor.dateFormatter = dateFormatter;
    } else {
      const simpleDateFormat = new java.text.SimpleDateFormat(
        'MM/dd/yyyy',
        java.util.Locale.US
      );
      editor.setDateFormat(simpleDateFormat);
    }
  }
}
