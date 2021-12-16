import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CourseServiceProxy,
  CreateCourseDto
} from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html'
})
export class CreateCourseComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  course = new CreateCourseDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _courseService: CourseServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void { }

  save(): void {
    this.saving = true;
    this.course.startDate = moment(this.course.startDate, 'DD-MM-YYYY');
    this.course.endDate = moment(this.course.endDate, 'DD-MM-YYYY');

    this._courseService.create(this.course).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
