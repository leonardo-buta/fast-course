import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  QuestionDto,
  QuestionDtoPagedResultDto,
  QuestionServiceProxy
} from '@shared/service-proxies/service-proxies';
import { CreateQuestionComponent } from './create-question/create-question.component';

class PagedQuestionsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './questions.component.html',
  animations: [appModuleAnimation()]
})
export class QuestionsComponent extends PagedListingComponentBase<QuestionDto> {
  questions: QuestionDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _questionService: QuestionServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createQuestion(): void {
    this.showCreateOrEditQuestionDialog();
  }

  editQuestion(question: QuestionDto): void {
    this.showCreateOrEditQuestionDialog(question.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedQuestionsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._questionService
      .getList()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: QuestionDtoPagedResultDto) => {
        this.questions = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(question: QuestionDto): void {
    abp.message.confirm(
      this.l('QuestionDeleteWarningMessage', question.questionDescription),
      undefined,
      (result: boolean) => {
        if (result) {
          // this._questionService.delete(question.id).subscribe(() => {
          //   abp.notify.success(this.l('SuccessfullyDeleted'));
          //   this.refresh();
          // });
        }
      }
    );
  }

  private showCreateOrEditQuestionDialog(id?: number): void {
    let createOrEditQuestionDialog: BsModalRef;
    if (!id) {
      createOrEditQuestionDialog = this._modalService.show(
        CreateQuestionComponent,
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

    createOrEditQuestionDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
