import { Component, OnInit, NgZone } from '@angular/core';

import { RouterExtensions } from '@nativescript/angular';
import { TranslateService } from '@ngx-translate/core';

import { BaseFormComponent } from '@src/app/shared/component/base-form.component';
import { SpaceTypeService } from '@src/app/_services/space-type.service';
import { DialogService } from '@src/app/_services/dialog.service';
import { SpaceTypeFormSource } from '@src/app/_models/form/space-type-form.model';
import { SpaceType } from '@src/app/_models/space-type.model';
import { SpaceTypeDto } from '@src/app/_dtos/space-type.dto';
import { IBaseFormComponent } from '@src/app/_interfaces/components/ibase-form.component.interface';
import { SpaceTypeMapper } from '@src/app/_helpers/mappers/space-type-mapper.helper';

@Component({
  selector: 'ns-space-type-add',
  templateUrl: './space-type-add.component.html',
  styleUrls: ['./space-type-add.component.scss'],
})
export class SpaceTypeAddComponent
  extends BaseFormComponent<SpaceType, SpaceTypeFormSource, SpaceTypeDto>
  implements IBaseFormComponent, OnInit {
  constructor(
    public dialogService: DialogService,
    public ngZone: NgZone,
    public router: RouterExtensions,
    public spaceTypeService: SpaceTypeService,
    public translateService: TranslateService
  ) {
    super(dialogService, ngZone, router, translateService);
    this._entityService = spaceTypeService;
    this._entityDtoMapper = new SpaceTypeMapper();
  }

  ngOnInit() {
    this._entityFormSource = this._entityDtoMapper.initFormSource();
    this.initDialogTexts();
  }

  initDialogTexts() {
    this._saveNewDialogTexts = {
      title: this.translateService.instant(
        'SPACE_TYPE_ADD_DETAILS_PAGE.FORM_CONTROL.ADD_DIALOG.TITLE'
      ),
      confirmMessage: this.translateService.instant(
        'SPACE_TYPE_ADD_DETAILS_PAGE.FORM_CONTROL.ADD_DIALOG.CONFIRM_MESSAGE'
      ),
      successMessage: this.translateService.instant(
        'SPACE_TYPE_ADD_DETAILS_PAGE.FORM_CONTROL.ADD_DIALOG.SUCCESS_MESSAGE'
      ),
      errorMessage: this.translateService.instant(
        'SPACE_TYPE_ADD_DETAILS_PAGE.FORM_CONTROL.ADD_DIALOG.ERROR_MESSAGE'
      ),
    };
  }
}
