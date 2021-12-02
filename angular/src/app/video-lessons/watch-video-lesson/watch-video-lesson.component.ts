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
  VideoLessonDto
} from '@shared/service-proxies/service-proxies';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-watch-video-lesson',
  templateUrl: './watch-video-lesson.component.html'
})
export class WatchVideoLessonComponent extends AppComponentBase
  implements OnInit {
  videoLesson = new VideoLessonDto();
  id: number;
  safeUrl: SafeResourceUrl;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _videoLessonService: VideoLessonServiceProxy,
    public bsModalRef: BsModalRef,
    public sanitizer: DomSanitizer    
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._videoLessonService.getById(this.id)
      .subscribe((result: VideoLessonDto) => {
        this.videoLesson = result;
        this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.videoLesson.url);  
      });
  }
}
