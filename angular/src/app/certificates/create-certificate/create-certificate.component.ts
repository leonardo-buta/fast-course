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
  CertificateServiceProxy,
  CreateCertificateDto,
  CourseSelectDto,
  CourseServiceProxy
} from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-create-certificate',
  templateUrl: './create-certificate.component.html'
})
export class CreateCertificateComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  certificate = new CreateCertificateDto();
  courses: CourseSelectDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _certificateService: CertificateServiceProxy,
    public _courseService: CourseServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._courseService.getListSelect()
      .subscribe((result: CourseSelectDto[]) => {
        this.courses = result;
      });
  }

  save(): void {
    this.saving = true;
    this.certificate.expirationDate = moment(this.certificate.expirationDate, 'DD-MM-YYYY');

    this._certificateService.create(this.certificate).subscribe(
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
