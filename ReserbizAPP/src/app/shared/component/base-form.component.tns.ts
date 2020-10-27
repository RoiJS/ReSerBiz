import { Component, OnInit, ViewChild, NgZone } from '@angular/core';

import { RouterExtensions } from 'nativescript-angular/router';
import { RadDataFormComponent } from 'nativescript-ui-dataform/angular/dataform-directives';
import { ios } from 'tns-core-modules/application';

import { finalize } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

import { IBaseFormSource } from '@src/app/_interfaces/ibase-form-source.interface';
import { IBaseDialogTexts } from '@src/app/_interfaces/ibase-dialog-texts.interface';
import { IBaseDtoEntityMapper } from '@src/app/_interfaces/ibase-dto-entity-mapper.interface';
import { IBaseService } from '@src/app/_interfaces/ibase-service.interface';
import { IBaseDto } from '@src/app/_interfaces/ibase-dto.interface';
import { IEntity } from '@src/app/_interfaces/ientity.interface';

import { ButtonOptions } from '@src/app/_enum/button-options.enum';
import { DialogService } from '@src/app/_services/dialog.service';
import { BaseFormHelper } from '@src/app/_helpers/base-form.helper';

declare var NSDateFormatter: any;
declare var java: any;

@Component({
  template: ``,
})
export class BaseFormComponent<
    TEntity extends IEntity,
    TFormSource extends IBaseFormSource<TFormSource>,
    TDtoEntity extends IBaseDto
  >
  extends BaseFormHelper<TFormSource>
  implements OnInit {
  @ViewChild(RadDataFormComponent, { static: false })
  formSource: RadDataFormComponent;

  protected _currentEntity: TEntity;
  protected _currentFormEntityId: number;

  protected _isBusy = false;

  protected _entityFormSource: TFormSource;
  protected _entityFormSourceOriginal: TFormSource;

  protected _saveNewDialogTexts: IBaseDialogTexts;
  protected _updateDialogTexts: IBaseDialogTexts;

  protected _entityService: IBaseService<TEntity>;
  protected _entityDtoMapper: IBaseDtoEntityMapper<
    TEntity,
    TFormSource,
    TDtoEntity
  >;

  constructor(
    public dialogService: DialogService,
    public ngZone: NgZone,
    public router: RouterExtensions,
    public translateService: TranslateService
  ) {
    super();
  }

  ngOnInit() {}

  saveNewInformation() {
    const isFormInvalid = this.formSource.dataForm.hasValidationErrors();

    if (!isFormInvalid) {
      this.dialogService
        .confirm(
          this._saveNewDialogTexts.title,
          this._saveNewDialogTexts.confirmMessage
        )
        .then((res) => {
          if (res === ButtonOptions.YES) {
            this._isBusy = true;

            const dtoToCreate = this._entityDtoMapper.mapFormSourceToDto(
              this._entityFormSource
            );

            this._entityService
              .saveNewEntity({
                id: this._currentFormEntityId,
                dtoEntity: dtoToCreate,
              })
              .pipe(
                finalize(() => {
                  this.ngZone.run(() => {
                    this._isBusy = false;
                  });
                })
              )
              .subscribe(
                () => {
                  this.dialogService.alert(
                    this._saveNewDialogTexts.title,
                    this._saveNewDialogTexts.successMessage,
                    () => {
                      this._entityService.reloadListFlag();
                      this.router.back();
                    }
                  );
                },
                (error: Error) => {
                  this.dialogService.alert(
                    this._saveNewDialogTexts.title,
                    this._saveNewDialogTexts.errorMessage
                  );
                }
              );
          }
        });
    }
  }

  updateInformation() {
    const isFormInvalid = this.formSource.dataForm.hasValidationErrors();
    const isFormHasChanged = !this._entityFormSource.isSame(
      this._entityFormSourceOriginal
    );

    if (!isFormInvalid && isFormHasChanged) {
      this.dialogService
        .confirm(
          this._updateDialogTexts.title,
          this._updateDialogTexts.confirmMessage
        )
        .then((res) => {
          if (res === ButtonOptions.YES) {
            this._isBusy = true;

            const dtoForUpdate = this._entityDtoMapper.mapFormSourceToDto(
              this._entityFormSource
            );

            this._entityService
              .updateEntity({
                id: this._currentFormEntityId,
                dtoEntity: dtoForUpdate,
              })
              .pipe(finalize(() => (this._isBusy = false)))
              .subscribe(
                () => {
                  this.dialogService.alert(
                    this._updateDialogTexts.title,
                    this._updateDialogTexts.successMessage,
                    () => {
                      this._entityService.reloadListFlag();
                      this.router.back();
                    }
                  );
                },
                (error: Error) => {
                  this.dialogService.alert(
                    this._updateDialogTexts.title,
                    this._updateDialogTexts.errorMessage
                  );
                }
              );
          }
        });
    }
  }

  // Unfortunately, date control offerred by RadDataForm does not support
  // Date Formatting so this is a native way to format date.
  protected changeDateFormatting(editor) {
    if (ios) {
      const dateFormatter = NSDateFormatter.alloc().init();
      dateFormatter.dateFormat = 'MM/dd/yyyy';
      editor.dateFormatter = dateFormatter;
    } else {
      const simpleDateFormat = new java.text.SimpleDateFormat(
        'MM/dd/yyyy',
        java.util.Locale.US
      );
      editor.setDateFormat(simpleDateFormat);
    }
  }

  get entityFormSource(): TFormSource {
    return this._entityFormSource;
  }

  get isBusy(): boolean {
    return this._isBusy;
  }

  get currentEntity(): TEntity {
    return this._currentEntity;
  }
}
