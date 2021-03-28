import {
  Component,
  OnInit,
  OnDestroy,
  ViewChild,
  AfterViewInit,
  ChangeDetectorRef,
  ViewContainerRef,
  NgZone,
} from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import {
  connectionType,
  getConnectionType,
  startMonitoring,
  stopMonitoring,
} from '@nativescript/core/connectivity';

import { RouterExtensions } from '@nativescript/angular';
import { RadSideDrawerComponent } from 'nativescript-ui-sidedrawer/angular';
import {
  RadSideDrawer,
  DrawerTransitionBase,
  SlideInOnTopTransition,
} from 'nativescript-ui-sidedrawer';
import { Application } from '@nativescript/core';
import { ios } from '@nativescript/core/application';
import { ad } from '@nativescript/core/utils/utils';

import { TranslateService } from '@ngx-translate/core';

import { SignalrCore } from 'nativescript-signalr-core';

import { filter } from 'rxjs/operators';
import { Subscription } from 'rxjs';

import { AuthService } from './_services/auth.service';
import { CheckConnectionService } from './_services/check-connection.service';
import { SideDrawerService } from './_services/side-drawer.service';
import { UIService } from './_services/ui.service';
import { SettingsService } from './_services/settings.service';
import { GeneralInformationService } from './_services/general-information.service';

import { MainMenu } from './_models/main-menu.model';

import { environment } from '@src/environments/environment';

// Import Websocket to be able to use SignalR
declare var require;
const WebSocket = require('nativescript-websockets');

@Component({
  selector: 'ns-app',
  moduleId: module.id,
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild(RadSideDrawerComponent, { static: false })
  drawerComponent: RadSideDrawerComponent;

  mainMenuList: MainMenu[];

  private drawer: RadSideDrawer;
  private drawerSub: Subscription;
  private currentFullnameSub: Subscription;
  private currentUsernameSub: Subscription;
  private checkConnectionSub: Subscription;

  private _currentFullname: string;
  private _currentUsername: string;

  private activatedUrl: string;
  private _sideDrawerTransition: DrawerTransitionBase;

  private signalrCore: SignalrCore;

  constructor(
    private authService: AuthService,
    private checkConnectionService: CheckConnectionService,
    private changeDetectionRef: ChangeDetectorRef,
    private generalInformationService: GeneralInformationService,
    private ngZone: NgZone,
    private router: Router,
    private routerExtensions: RouterExtensions,
    private settingsService: SettingsService,
    private sideDrawerService: SideDrawerService,
    private uiService: UIService,
    private vcRef: ViewContainerRef,
    private translate: TranslateService
  ) {
    this.signalrCore = new SignalrCore();
    this.translate.setDefaultLang('en');
  }

  ngOnInit(): void {
    (async () => {
      this.initUserInfoSubscriptions();
      this.initRadDrawerSubscription();

      this.uiService.setRootVCRef(this.vcRef);

      this.activatedUrl = '/dashboard';
      this.mainMenuList = this.sideDrawerService.mainMenu;
      this._sideDrawerTransition = new SlideInOnTopTransition();

      this.initRouterEvents();
      await this.settingsService.getSettingsDetails();
    })();

    this.monitorInternetConnectivity();
    this.initMonitorConnectivityRedirection();

    this.connectToSignalRServer();
  }

  ngOnDestroy() {
    if (this.drawerSub) {
      this.drawerSub.unsubscribe();
    }

    if (this.currentFullnameSub) {
      this.currentFullnameSub.unsubscribe();
    }

    if (this.currentUsernameSub) {
      this.currentUsernameSub.unsubscribe();
    }

    if (this.checkConnectionSub) {
      this.checkConnectionSub.unsubscribe();
    }

    stopMonitoring();
  }

  ngAfterViewInit() {
    this.drawer = this.drawerComponent.sideDrawer;
    this.changeDetectionRef.detectChanges();
  }

  onSignout() {
    this.uiService.toggleDrawer();
    this.authService.logout();
  }

  isComponentSelected(url: string): boolean {
    return this.activatedUrl.indexOf(url) > -1;
  }

  onNavItemTap(navItemRoute: string): void {
    this.routerExtensions.navigate([navItemRoute], {
      transition: {
        name: 'slideLeft',
      },
    });

    const sideDrawer = <RadSideDrawer>(<any>Application.getRootView());
    sideDrawer.closeDrawer();
  }

  private connectToSignalRServer() {
    this.signalrCore
      .start(`${environment.reserbizAPIEndPoint}/systemUpdateHub`)
      .then((isConnected: boolean) => {
        console.log('SignalR Connection Status: ', isConnected);
        if (isConnected) {
          this.initBroadCastSystemUpdateStatus();
        }
      });
  }

  private initBroadCastSystemUpdateStatus() {
    this.signalrCore.on('BroadCastSystemUpdateStatus', () => {
      const currentConnectionType = getConnectionType();

      this.checkConnectionService.currentConnectionType.next(
        currentConnectionType
      );
    });
  }

  private initUserInfoSubscriptions() {
    this.currentFullnameSub = this.authService.currentFullname.subscribe(
      (currentFullname: string) => {
        this._currentFullname = currentFullname;
      }
    );

    this.currentUsernameSub = this.authService.currentUsername.subscribe(
      (currentUsername: string) => {
        this._currentUsername = currentUsername;
      }
    );
  }

  private initRadDrawerSubscription() {
    this.drawerSub = this.uiService.drawerState.subscribe(() => {
      if (this.drawer) {
        this.drawer.toggleDrawerState();
        this.hideKeyboard();
      }
    });
  }

  private initRouterEvents() {
    this.router.events
      .pipe(filter((event: any) => event instanceof NavigationEnd))
      .subscribe(
        (event: NavigationEnd) => (this.activatedUrl = event.urlAfterRedirects)
      );
  }

  private hideKeyboard(): void {
    if (ios) {
      ios.nativeApp.sendActionToFromForEvent(
        'resignFirstResponder',
        null,
        null,
        null
      );
    } else {
      ad.dismissSoftInput();
    }
  }

  private monitorInternetConnectivity() {
    const currentConnectionType = getConnectionType();

    this.checkConnectionService.currentConnectionType.next(
      currentConnectionType
    );

    startMonitoring((type) => {
      this.checkConnectionService.currentConnectionType.next(type);
    });
  }

  private initMonitorConnectivityRedirection() {
    this.checkConnectionSub = this.checkConnectionService.currentConnectionType.subscribe(
      (currentConnection: connectionType) => {
        this.ngZone.run(() => {
          let route = '';
          if (currentConnection === connectionType.none) {
            route = '/no-connection';
            this.routerExtensions.navigate([route]);
          } else {
            this.authService
              .autoLogin()
              .toPromise()
              .then(async (result: boolean) => {
                if (result) {
                  route = '/dashboard';
                } else {
                  route = '/auth';
                }

                const generalInformation = await this.generalInformationService.getGeneralInformation();

                // Check if the system is currently under system update
                if (generalInformation.systemUpdateStatus) {
                  route = '/system-update';

                  // Auto-logout the user during system update.
                  this.authService.logout();
                }

                this.routerExtensions.navigate([route]);
              });
          }
        });
      }
    );
  }

  get currentUserFullname(): string {
    return this._currentFullname;
  }

  get currentUsername(): string {
    return this._currentUsername;
  }

  get sideDrawerTransition(): DrawerTransitionBase {
    return this._sideDrawerTransition;
  }
}
