import { Location } from '@angular/common';
import {
  Component,
  OnInit,
  OnDestroy,
  NgZone,
  ElementRef,
  ChangeDetectorRef,
  ViewContainerRef,
} from '@angular/core';

import { TranslateService } from '@ngx-translate/core';
import { RouterExtensions } from 'nativescript-angular/router';
import {
  ModalDialogService,
  ModalDialogOptions,
} from 'nativescript-angular/modal-dialog';

import { BaseListComponent } from '@src/app/shared/component/base-list.component';

import { Contract } from '@src/app/_models/contract.model';
import { IBaseListComponent } from '@src/app/_interfaces/ibase-list-component.interface';

import { ContractService } from '@src/app/_services/contract.service';
import { DialogService } from '@src/app/_services/dialog.service';
import { StorageService } from '@src/app/_services/storage.service';
import { ContractPaginationList } from '@src/app/_models/contract-pagination-list.model';
import { ContractFilterDialogComponent } from '../contract-filter-dialog/contract-filter-dialog.component';
import { ContractFilter } from '@src/app/_models/contract-filter.model';
import { IContractFilter } from '@src/app/_interfaces/icontract-filter.interface';
import { FilterOptionEnum } from '@src/app/_enum/filter-option.enum';

@Component({
  selector: 'ns-contract-list',
  templateUrl: './contract-list.component.html',
  styleUrls: ['./contract-list.component.scss'],
})
export class ContractListComponent extends BaseListComponent<Contract>
  implements IBaseListComponent, OnInit, OnDestroy {
  private _openContractsCount: number;

  private CONTRACT_FILTER_TENANT_ID = 'contractFilter_tenantId';
  private CONTRACT_FILTER_ACTIVE_FROM = 'contractFilter_activeFrom';
  private CONTRACT_FILTER_ACTIVE_TO = 'contractFilter_activeTo';
  private CONTRACT_FILTER_NEXT_DUE_DATE_FROM = 'contractFilter_nextDueDateFrom';
  private CONTRACT_FILTER_NEXT_DUE_DATE_TO = 'contractFilter_nextDueDateTo';
  private CONTRACT_FILTER_OPEN_CONTRACT = 'contractFilter_openContract';

  constructor(
    protected contractService: ContractService,
    protected changeDetectorRef: ChangeDetectorRef,
    protected dialogService: DialogService,
    protected location: Location,
    protected ngZone: NgZone,
    protected translateService: TranslateService,
    protected router: RouterExtensions,
    private modalDialogService: ModalDialogService,
    private vcRef: ViewContainerRef,
    private storageService: StorageService
  ) {
    super(dialogService, location, ngZone, router, translateService);
    this.entityService = contractService;
    this.changeDetectorRef = changeDetectorRef;
    this._openContractsCount = 0;

    // take note to override the filter from the
    // base component list if derived component
    // class need to support more complex
    // filter feature.
    this._entityFilter = new ContractFilter();
    this._entityFilter.page = 1;
  }

  ngOnInit() {
    this._loadListFlagSub = this.contractService.loadContractListFlag.subscribe(
      () => {
        this.initFilterOptions();
        this.getPaginatedEntities(
          (contractPaginationList: ContractPaginationList) => {
            this._openContractsCount =
              contractPaginationList.totalNumberOfOpenContracts;
            this._listItems.map((contract: Contract) => {
              contract.convertDurationBeforeContractEndsToString(
                this.translateService
              );
            });
          }
        );
      }
    );

    this.initDialogTexts();
    super.ngOnInit();
  }

  initDialogTexts() {
    this._deleteMultipleItemsDialogTexts = {
      title: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACTS_DIALOG.TITLE'
      ),
      confirmMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACTS_DIALOG.CONFIRM_MESSAGE'
      ),
      successMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACTS_DIALOG.SUCCESS_MESSAGE'
      ),
      errorMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACTS_DIALOG.ERROR_MESSAGE'
      ),
    };

    this._deleteItemDialogTexts = {
      title: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACT_DIALOG.TITLE'
      ),
      confirmMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACT_DIALOG.CONFIRM_MESSAGE'
      ),
      successMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACT_DIALOG.SUCCESS_MESSAGE'
      ),
      errorMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.REMOVE_CONTRACT_DIALOG.ERROR_MESSAGE'
      ),
    };

    this._deactivateMultipleItemDialogTexts = {
      title: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACTS_DIALOG.TITLE'
      ),
      confirmMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACTS_DIALOG.CONFIRM_MESSAGE'
      ),
      successMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACTS_DIALOG.SUCCESS_MESSAGE'
      ),
      errorMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACTS_DIALOG.ERROR_MESSAGE'
      ),
    };

    this._deactivateItemDialogTexts = {
      title: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACT_DIALOG.TITLE'
      ),
      confirmMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACT_DIALOG.CONFIRM_MESSAGE'
      ),
      successMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACT_DIALOG.SUCCESS_MESSAGE'
      ),
      errorMessage: this.translateService.instant(
        'CONTRACT_LIST_PAGE.ARCHIVE_CONTRACT_DIALOG.ERROR_MESSAGE'
      ),
    };
  }

  ngOnDestroy() {
    super.ngOnDestroy();
  }

  initFilterOptions() {
    const tenantId = this.storageService.getString(
      this.CONTRACT_FILTER_TENANT_ID
    );
    const activeFrom = this.storageService.getString(
      this.CONTRACT_FILTER_ACTIVE_FROM
    );
    const activeTo = this.storageService.getString(
      this.CONTRACT_FILTER_ACTIVE_TO
    );
    const nextDueDateFrom = this.storageService.getString(
      this.CONTRACT_FILTER_NEXT_DUE_DATE_FROM
    );
    const nextDueDateTo = this.storageService.getString(
      this.CONTRACT_FILTER_NEXT_DUE_DATE_TO
    );
    const openContract = this.storageService.getString(
      this.CONTRACT_FILTER_OPEN_CONTRACT
    );

    if (tenantId) {
      (<ContractFilter>this._entityFilter).tenantId = Number(tenantId);
    }

    if (activeFrom) {
      (<ContractFilter>this._entityFilter).activeFrom = new Date(activeFrom);
    }

    if (activeTo) {
      (<ContractFilter>this._entityFilter).activeTo = new Date(activeTo);
    }

    if (nextDueDateFrom) {
      (<ContractFilter>this._entityFilter).nextDueDateFrom = new Date(
        nextDueDateFrom
      );
    }

    if (nextDueDateTo) {
      (<ContractFilter>this._entityFilter).nextDueDateTo = new Date(
        nextDueDateTo
      );
    }

    if (openContract) {
      (<ContractFilter>this._entityFilter).openContract = Boolean(
        JSON.parse(openContract)
      );
    }
  }

  storeFilterOptions(contractFilter: ContractFilter) {
    const tenantId = contractFilter.tenantId;
    const activeFrom = contractFilter.activeFrom;
    const activeTo = contractFilter.activeTo;
    const nextDueDateFrom = contractFilter.nextDueDateFrom;
    const nextDueDateTo = contractFilter.nextDueDateTo;
    const openContract = contractFilter.openContract;

    if (tenantId) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_TENANT_ID,
        tenantId.toString()
      );
    }

    if (activeFrom) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_ACTIVE_FROM,
        activeFrom.toString()
      );
    }

    if (activeTo) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_ACTIVE_TO,
        activeTo.toString()
      );
    }

    if (nextDueDateFrom) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_NEXT_DUE_DATE_FROM,
        nextDueDateFrom.toString()
      );
    }

    if (nextDueDateTo) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_NEXT_DUE_DATE_TO,
        nextDueDateTo.toString()
      );
    }

    if (openContract) {
      this.storageService.storeString(
        this.CONTRACT_FILTER_OPEN_CONTRACT,
        openContract.toString()
      );
    }
  }

  resetFilterOptions() {
    this.storageService.remove(this.CONTRACT_FILTER_TENANT_ID);
    this.storageService.remove(this.CONTRACT_FILTER_ACTIVE_FROM);
    this.storageService.remove(this.CONTRACT_FILTER_ACTIVE_TO);
    this.storageService.remove(this.CONTRACT_FILTER_NEXT_DUE_DATE_FROM);
    this.storageService.remove(this.CONTRACT_FILTER_NEXT_DUE_DATE_TO);
    this.storageService.remove(this.CONTRACT_FILTER_OPEN_CONTRACT);
  }

  initFilterDialog(): Promise<any> {
    const dialogOptions: ModalDialogOptions = {
      viewContainerRef: this.vcRef,
      context: {
        contractFilter: <ContractFilter>this._entityFilter,
      },
      fullscreen: false,
      animated: true,
    };

    return this.modalDialogService.showModal(
      ContractFilterDialogComponent,
      dialogOptions
    );
  }

  openFilterDialog() {
    this.initFilterDialog().then(
      (data: { result: FilterOptionEnum; filter: ContractFilter }) => {
        if (!data) {
          return;
        }

        if (data.result === FilterOptionEnum.Confirm) {
          this.storeFilterOptions(data.filter);
        } else {
          (<ContractFilter>this._entityFilter).reset();
          this.resetFilterOptions();
        }

        this.entityService.reloadListFlag();
      }
    );
  }

  get openContractsCount(): number {
    return this._openContractsCount;
  }
}
