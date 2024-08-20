import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomizeTextFormItemComponent } from './../customize-text-form-item/customize-text-form-item.component';
import { Component } from '@angular/core';

@Component({
  selector: 'app-customize-number-form-item',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './customize-number-form-item.component.html',
  styleUrl: './customize-number-form-item.component.scss'
})
export class CustomizeNumberFormItemComponent extends CustomizeTextFormItemComponent {
}
