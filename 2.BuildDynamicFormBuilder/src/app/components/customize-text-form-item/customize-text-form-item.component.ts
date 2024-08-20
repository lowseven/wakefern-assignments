import { Component, Input, Output } from '@angular/core';
import { FormItem } from '../../models/field-type.model';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-customize-text-form-item',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './customize-text-form-item.component.html',
  styleUrl: './customize-text-form-item.component.scss'
})
export class CustomizeTextFormItemComponent {
  @Input() newFormItem!: FormItem<string>;

  
}
