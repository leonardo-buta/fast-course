import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {
  shownLoginName = '';

  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {
    this.shownLoginName = this.appSession.getShownLoginName();
  }
}
