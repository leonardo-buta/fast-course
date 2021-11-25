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
  VideoLessonServiceProxy,
  CreateVideoLessonDto,
  CourseSelectDto,
  CourseServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-video-lesson',
  templateUrl: './create-video-lesson.component.html'
})
export class CreateVideoLessonComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  videoLesson = new CreateVideoLessonDto();
  courses: CourseSelectDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _videoLessonService: VideoLessonServiceProxy,
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
    this._videoLessonService.create(this.videoLesson).subscribe(
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
