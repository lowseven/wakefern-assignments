import { v4 } from 'uuid';

export interface IOptionItem {
  key: string;
  value: string;
}

export class FormItem<T> {
  label: string;
  uuid: string = v4().toString();
  fieldType: 'text' | 'number' | 'radio' | 'dropdown' | 'checkbox';
  isRequired: boolean;
  defaultValue?: string;
  placeholder: string;
  value?: T | undefined;
  minMaxValidation?: number[];
  options?: IOptionItem[];

  constructor(
    defaults: {
      label?: string;
      fieldType?: 'text' | 'number' | 'radio' | 'dropdown' | 'checkbox';
      isRequired?: boolean;
      placeholder?: string;
      defaultValue?: string;
      value?: T | undefined;
      minMaxValidation?: number[];
      options?: IOptionItem[];
    } = {}
  ) {
    this.label = defaults.label || 'Label';
    this.fieldType = defaults.fieldType || 'text';
    this.isRequired = defaults.isRequired || false;
    this.options = defaults.options;
    this.minMaxValidation = this.minMaxValidation || [0, 20];
    this.placeholder = defaults.placeholder || '';
    this.value = defaults.value;
  }

  get minLength(): string {
    return this.minMaxValidation
      ? this.minMaxValidation.length > 1
        ? this.minMaxValidation[0].toString()
        : ''
      : '';
  }

  set minLength(value: string) {
    if (this.minMaxValidation) {
      this.minMaxValidation![0] = parseInt(value);
      if (this.minLength > this.maxLength) this.maxLength += 2;
    }
  }

  get maxLength(): string {
    return this.minMaxValidation
      ? this.minMaxValidation.length > 1
        ? this.minMaxValidation[1].toString()
        : ''
      : '';
  }

  set maxLength(value: string) {
    if (this.minMaxValidation) this.minMaxValidation![1] = parseInt(value);
  }
}
