import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  VideoLessonDto,
  VideoLessonDtoPagedResultDto,
  VideoLessonServiceProxy
} from '@shared/service-proxies/service-proxies';
import { CreateVideoLessonComponent } from './create-video-lesson/create-video-lesson.component';

class PagedVideoLessonsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './video-lessons.component.html',
  animations: [appModuleAnimation()]
})
export class VideoLessonsComponent extends PagedListingComponentBase<VideoLessonDto> {
  videoLessons: VideoLessonDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _videoLessonService: VideoLessonServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createVideoLesson(): void {
    this.showCreateOrEditVideoLessonDialog();
  }

  editVideoLesson(videoLesson: VideoLessonDto): void {
    this.showCreateOrEditVideoLessonDialog(videoLesson.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedVideoLessonsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._videoLessonService
      .getList()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: VideoLessonDtoPagedResultDto) => {
        this.videoLessons = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(videoLesson: VideoLessonDto): void {
    abp.message.confirm(
      this.l('VideoLessonDeleteWarningMessage', videoLesson.name),
      undefined,
      (result: boolean) => {
        if (result) {
          // this._videoLessonService.delete(video-lesson.id).subscribe(() => {
          //   abp.notify.success(this.l('SuccessfullyDeleted'));
          //   this.refresh();
          // });
        }
      }
    );
  }

  private showCreateOrEditVideoLessonDialog(id?: number): void {
    let createOrEditVideoLessonDialog: BsModalRef;
    if (!id) {
      createOrEditVideoLessonDialog = this._modalService.show(
        CreateVideoLessonComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      // createOrEditCourseDialog = this._modalService.show(
      //   EditCourseComponent,
      //   {
      //     class: 'modal-lg',
      //     initialState: {
      //       id: id,
      //     },
      //   }
      // );
    }

    createOrEditVideoLessonDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
