import { Component, OnInit } from '@angular/core';
import { PageRoute, RouterExtensions } from 'nativescript-angular/router';

import { TenantService } from '@src/app/_services/tenant.service';
import { Tenant } from '@src/app/_models/tenant.model';

@Component({
  selector: 'ns-tenant-details',
  templateUrl: './tenant-details.component.html',
  styleUrls: ['./tenant-details.component.scss']
})
export class TenantDetailsComponent implements OnInit {
  private _actionBarTitle = '';

  constructor(
    private pageRoute: PageRoute,
    private router: RouterExtensions,
    private tenantService: TenantService
  ) {}

  ngOnInit() {
    this.pageRoute.activatedRoute.subscribe(activatedRoute => {
      activatedRoute.paramMap.subscribe(paramMap => {
        const tenantId = +paramMap.get('tenantId');
        this.tenantService
          .getTenant(tenantId)
          .subscribe((tenant: Tenant) => {
            this._actionBarTitle = tenant.fullName;
          });
      });
    });
  }

  get ActionBarTitle(): string {
    return this._actionBarTitle;
  }
}
