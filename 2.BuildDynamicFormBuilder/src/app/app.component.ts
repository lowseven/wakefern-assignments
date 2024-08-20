import { CustomizeCheckboxFormItemComponent } from './components/customize-checkbox-form-item/customize-checkbox-form-item.component';
import { CustomizeDropdownFormItemComponent } from './components/customize-dropdown-form-item/customize-dropdown-form-item.component';
import { CustomizeNumberFormItemComponent } from './components/customize-number-form-item/customize-number-form-item.component';
import { CustomizeTextFormItemComponent } from './components/customize-text-form-item/customize-text-form-item.component';
import { Component, Input } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormItemsService } from './services/form-items.service';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FormItem, IOptionItem } from './models/field-type.model';
import { FormsModule } from '@angular/forms';
import { DynamicFormItemComponent } from './components/dynamic-form-item/dynamic-form-item.component';
import { v4 } from 'uuid';
import { CustomizeRadioFormItemComponent } from './components/customize-radio-form-item/customize-radio-form-item.component';
import {
  CdkDropList,
  CdkDrag,
  CdkDragDrop,
  moveItemInArray,
} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ReactiveFormsModule,
    FormsModule,
    DynamicFormItemComponent,
    CustomizeTextFormItemComponent,
    CustomizeNumberFormItemComponent,
    CustomizeRadioFormItemComponent,
    CustomizeDropdownFormItemComponent,
    CustomizeCheckboxFormItemComponent,
    CdkDropList,
    CdkDrag,
  ],
  providers: [FormItemsService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'BuildDynamicFormBuilder';
  form!: FormGroup;
  payLoad = '';

  newFormItem: FormItem<string>;

  @Input() formItems: FormItem<string>[] = [];

  constructor(private itemsService: FormItemsService) {
    this.newFormItem = <FormItem<string>>{
      label: '',
      isRequired: false,
      placeholder: '',
      fieldType: 'text',
      uuid: v4().toString(),
    };

    this.formItems = [
      // <FormItem<string>>{
      //   label: 'lorem ipsum',
      //   isRequired: true,
      //   placeholder: 'a placeholder',
      //   fieldType: 'text',
      //   minMaxValidation: [2, 7],
      // },
      // <FormItem<string>>{
      //   label: 'a radio ipsum',
      //   isRequired: true,
      //   placeholder: 'a placeholder',
      //   fieldType: 'radio',
      //   options: [
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '1',
      //     },
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '2',
      //     },
      //   ],
      // },
      // <FormItem<string>>{
      //   label: 'a radio ipsum',
      //   isRequired: true,
      //   placeholder: 'a placeholder',
      //   fieldType: 'radio',
      //   uuid: v4().toString(),
      //   options: [
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '1',
      //     },
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '2',
      //     },
      //   ],
      // },
      // <FormItem<string>>{
      //   label: 'lorem ipsum 2',
      //   isRequired: true,
      //   fieldType: 'dropdown',
      //   options: [
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '1'
      //     },
      //     <IOptionItem>{
      //       key: v4().toString(),
      //       value: '2'
      //     }
      //   ]
      // },
    ];

    this.form = this.itemsService.toFieldDataFormGroup(this.formItems);
  }

  onCreateFormItem() {
    this.formItems.push(this.newFormItem);
    this.newFormItem = <FormItem<string>>{
      label: '',
      isRequired: false,
      placeholder: '',
      fieldType: 'text',
      uuid: v4().toString(),
    };

    this.form = this.itemsService.toFieldDataFormGroup(this.formItems);
  }

  onSubmit() {
    const json = JSON.stringify(this.form.getRawValue());
    // console.log(json);

    const blob = new Blob([json], { type: 'application/json' });
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');

    link.href = url;
    link.setAttribute('download', v4().toString() + '.json');
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    window.URL.revokeObjectURL(url);

    alert('Operation completed successfully');
  }

  onRemoveItemClicked(item: string) {
    this.formItems = this.formItems.filter((i) => i.uuid !== item);
  }

  drop(event: CdkDragDrop<FormItem<string>[]>) {
    moveItemInArray(this.formItems, event.previousIndex, event.currentIndex);
  }
}
