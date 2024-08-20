import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormItem } from '../../models/field-type.model';


@Component({
  selector: 'app-dynamic-form-item',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './dynamic-form-item.component.html',
  styleUrl: './dynamic-form-item.component.scss',
})
export class DynamicFormItemComponent {
  @Input() formItem!: FormItem<string>;
  @Input() form!: FormGroup;

  @Output() onRemoveItemClicked: EventEmitter<any> = new EventEmitter<any>();

  get isValid(): boolean {
    if (this.form.controls[this.formItem.uuid!])
      return this.form.controls[this.formItem.uuid!].valid;
    return false;
  }

  onClickRemoveItem(event: any) {
    event.preventDefault(); //to prevent submit the form
    this.onRemoveItemClicked.emit(this.formItem.uuid);
  }
}
