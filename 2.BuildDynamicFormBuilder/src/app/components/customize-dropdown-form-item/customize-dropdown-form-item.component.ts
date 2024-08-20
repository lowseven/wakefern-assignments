import { Component, Input } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FormItem } from '../../models/field-type.model';
import { v4 } from 'uuid';

@Component({
  selector: 'app-customize-dropdown-form-item',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './customize-dropdown-form-item.component.html',
  styleUrl: './customize-dropdown-form-item.component.scss',
})
export class CustomizeDropdownFormItemComponent {
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
