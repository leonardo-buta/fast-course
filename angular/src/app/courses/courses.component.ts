import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  CourseDto,
  CourseDtoPagedResultDto,
  CourseServiceProxy
} from '@shared/service-proxies/service-proxies';
import { CreateCourseComponent } from './create-course/create-course.component';

class PagedCoursesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './courses.component.html',
  animations: [appModuleAnimation()]
})
export class CoursesComponent extends PagedListingComponentBase<CourseDto> {
  courses: CourseDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _courseService: CourseServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createCourse(): void {
    this.showCreateOrEditCourseDialog();
  }

  editCourse(course: CourseDto): void {
    this.showCreateOrEditCourseDialog(course.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedCoursesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._courseService
      .getList()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: CourseDtoPagedResultDto) => {
        this.courses = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(course: CourseDto): void {
    abp.message.confirm(
      this.l('CourseDeleteWarningMessage', course.name),
      undefined,
      (result: boolean) => {
        if (result) {
          // this._courseService.delete(course.id).subscribe(() => {
          //   abp.notify.success(this.l('SuccessfullyDeleted'));
          //   this.refresh();
          // });
        }
      }
    );
  }

  private showCreateOrEditCourseDialog(id?: number): void {
    let createOrEditCourseDialog: BsModalRef;
    if (!id) {
      createOrEditCourseDialog = this._modalService.show(
        CreateCourseComponent,
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

    createOrEditCourseDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
