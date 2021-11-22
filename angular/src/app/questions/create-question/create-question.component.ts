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
  QuestionServiceProxy,
  CreateQuestionDto,
  CourseSelectDto,
  CourseServiceProxy,
  CreateQuestionAlternativeDto} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-question',
  templateUrl: './create-question.component.html'
})
export class CreateQuestionComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  question = new CreateQuestionDto();
  courses: CourseSelectDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _questionService: QuestionServiceProxy,
    public _courseService: CourseServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {    
    this.question.questionAlternatives = [new CreateQuestionAlternativeDto({ "alternativeDescription": "", "isCorrect": false })];
    this._courseService.getListSelect()
      .subscribe((result: CourseSelectDto[]) => {
        this.courses = result;
      });
  }

  save(): void {
    this.saving = true;
    this._questionService.create(this.question).subscribe(
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
