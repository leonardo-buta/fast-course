import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  CertificateDto,
  CertificateDtoPagedResultDto,
  CertificateServiceProxy
} from '@shared/service-proxies/service-proxies';
import { CreateCertificateComponent } from './create-certificate/create-certificate.component';

class PagedCertificatesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './certificates.component.html',
  animations: [appModuleAnimation()]
})
export class CertificatesComponent extends PagedListingComponentBase<CertificateDto> {
  certificates: CertificateDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _certificateService: CertificateServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createCertificate(): void {
    this.showCreateOrEditCertificateDialog();
  }

  editCertificate(certificate: CertificateDto): void {
    this.showCreateOrEditCertificateDialog(certificate.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedCertificatesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._certificateService
      .getList()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: CertificateDtoPagedResultDto) => {
        this.certificates = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(certificate: CertificateDto): void {
    abp.message.confirm(
      this.l('CertificateDeleteWarningMessage', certificate.name),
      undefined,
      (result: boolean) => {
        if (result) {
          // this._certificateService.delete(certificate.id).subscribe(() => {
          //   abp.notify.success(this.l('SuccessfullyDeleted'));
          //   this.refresh();
          // });
        }
      }
    );
  }

  private showCreateOrEditCertificateDialog(id?: number): void {
    let createOrEditCertificateDialog: BsModalRef;
    if (!id) {
      createOrEditCertificateDialog = this._modalService.show(
        CreateCertificateComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      // createOrEditCertificateDialog = this._modalService.show(
      //   EditCertificateComponent,
      //   {
      //     class: 'modal-lg',
      //     initialState: {
      //       id: id,
      //     },
      //   }
      // );
    }

    createOrEditCertificateDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
