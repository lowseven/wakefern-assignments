import { Component, EventEmitter, Input, Output, output, ViewEncapsulation } from '@angular/core';
import { FormItem, IOptionItem } from '../../models/field-type.model';
import { v4 } from 'uuid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { encapsulateStyle } from '@angular/compiler';

@Component({
  selector: 'app-customize-radio-form-item',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './customize-radio-form-item.component.html',
  styleUrl: './customize-radio-form-item.component.scss',
})
export class CustomizeRadioFormItemComponent {
  @Input() newFormItem!: FormItem<string>;

  optionValue: string = '';

  onClick() {
    this.newFormItem.options = this.newFormItem.options || [];
    this.newFormItem.options.push({
      key: v4().toString(),
      value: this.optionValue,
    });
  }
}
