import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, BehaviorSubject } from 'rxjs';

import { environment } from '@src/environments/environment';
import { Tenant } from '../_models/tenant.model';

import { BaseService } from './base.service';

import { ContactPerson } from '../_models/contact-person.model';
import { TenantDto } from '../_dtos/tenant-create.dto';
import { ContactPersonDto } from '../_dtos/contact-person.dto';

import { TenantMapper } from '../_helpers/tenant-mapper.helper';
import { IBaseService } from '../_interfaces/ibase-service.interface';
import { IEntityFilter } from '../_interfaces/ientity-filter.interface';
import { IDtoProcess } from '../_interfaces/idto-process.interface';

@Injectable({
  providedIn: 'root',
})
export class TenantService extends BaseService<Tenant>
  implements IBaseService<Tenant> {
  private _loadTenantListFlag = new BehaviorSubject<void>(null);

  constructor(public http: HttpClient) {
    super(new TenantMapper(), http);
  }

  getTenant(tenantId: number): Observable<Tenant> {
    return this.getEntityFromServer(`${this._apiBaseUrl}/tenant/${tenantId}`);
  }

  getEntities(entityFilter: IEntityFilter): Observable<Tenant[]> {
    const searchKeyword = entityFilter ? entityFilter.searchKeyword : '';
    return this.getEntitiesFromServer(
      `${this._apiBaseUrl}/tenant?tenantName=${searchKeyword}`
    );
  }

  deleteMultipleItems(tenants: Tenant[]): Observable<void> {
    return this.deleteMultipleItemsOnServer(
      `${this._apiBaseUrl}/tenant/deleteMultipleTenants`,
      tenants
    );
  }

  deleteItem(tenantId: number): Observable<void> {
    return this.deleteItemOnServer(
      `${this._apiBaseUrl}/tenant/deleteTenant?tenantId=${tenantId}`
    );
  }

  setEntityStatus(tenantId: number, status: boolean): Observable<void> {
    return this.setEntityStatusOnServer(
      `${this._apiBaseUrl}/tenant/setStatus/${tenantId}/${status}`
    );
  }

  updateEntity(tenantForUpdateDto: IDtoProcess): Observable<void> {
    return this.updateEntityToServer(
      `${this._apiBaseUrl}/tenant/${tenantForUpdateDto.id}`,
      tenantForUpdateDto.dtoEntity
    );
  }

  saveNewTenant(
    newTenant: Tenant,
    newContactPersons: ContactPerson[]
  ): Observable<void> {
    const tenantCreateDto = new TenantDto(
      newTenant.firstName,
      newTenant.middleName,
      newTenant.lastName,
      newTenant.gender,
      newTenant.address,
      newTenant.contactNumber,
      newTenant.emailAddress
    );

    tenantCreateDto.contactPersons = newContactPersons.map(
      (cp: ContactPerson) => {
        return new ContactPersonDto(
          cp.firstName,
          cp.middleName,
          cp.lastName,
          cp.gender,
          cp.contactNumber
        );
      }
    );

    return this.http.post<void>(
      `${this._apiBaseUrl}/tenant/create`,
      tenantCreateDto
    );
  }

  reloadListFlag() {
    this._loadTenantListFlag.next();
  }

  get loadTenantListFlag(): BehaviorSubject<void> {
    return this._loadTenantListFlag;
  }
}
