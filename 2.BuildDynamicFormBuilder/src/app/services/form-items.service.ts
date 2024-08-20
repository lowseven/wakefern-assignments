import { Injectable } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FormItem } from '../models/field-type.model';

@Injectable({
  providedIn: 'root',
})
export class FormItemsService {
  public toFieldDataFormGroup(formItems: FormItem<string>[]) {
    const group: { [key: string]: AbstractControl<any> } = {};

    formItems.forEach((f) => {
      group[f.uuid!] = f.isRequired
        ? new FormControl(f.defaultValue, Validators.required)
        : new FormControl(f.defaultValue);

      if (f.fieldType === 'text' && (f.minMaxValidation?.length || 0) > 1) {
        group[f.uuid!].addValidators([
          Validators.minLength(f.minMaxValidation![0]),
          Validators.maxLength(f.minMaxValidation![1]),
        ]);
      } else if (
        f.fieldType === 'number' &&
        (f.minMaxValidation?.length || 0) > 1
      ) {
        group[f.uuid!].addValidators([
          Validators.min(f.minMaxValidation![0]),
          Validators.max(f.minMaxValidation![1]),
        ]);
      } else if (
        (f.fieldType === 'radio' || f.fieldType === 'checkbox') &&
        f.options &&
        f.options?.length > 0
      ) {
        f.options.forEach((e) => {
          group[e.key!] = f.isRequired
            ? new FormControl('', Validators.required)
            : new FormControl('');
        });
      } else if (
        f.fieldType === 'dropdown' &&
        f.options &&
        f.options?.length > 0
      ) {
        f.options.forEach((e) => {
          group[e.key!] = f.isRequired
            ? new FormControl(e.value, Validators.required)
            : new FormControl(e.value);
        });
      }
    });
    return new FormGroup(group);
  }
}
