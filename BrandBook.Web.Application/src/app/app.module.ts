import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgApexchartsModule } from 'ng-apexcharts';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';

import { AppLayoutComponent } from './components/application/app-layout.component';
import { AuthLayoutComponent } from './components/authentication/auth-layout.component';


import { AuthLoginComponent } from './components/authentication/login/auth-login.component';
import { AuthRegisterComponent } from './components/authentication/register/auth-register.component';
import { AuthForgotPasswordComponent } from './components/authentication/forgotPassword/auth-forgot-password.component';

import { LayoutLeftSidebarComponent } from './components/application/layout/left-sidebar/left-sidebar.component';
import { LayoutTopBarComponent } from './components/application/layout/top-bar/top-bar.component';
import { LayoutTitleAndBreadcrumbComponent } from './components/application/layout/title-and-breadcrumb/title-and-breadcrumb.component';

import { DashboardComponent } from './components/application/dashboard/dashboard.component';
import { RecentActivityChartComponent } from './components/application/dashboard/recent-activity-chart/recent-activity-chart.component';

import { BrandsOverviewComponent } from './components/application/brands/overview/brands-overview.component';
import { UserProfileComponent } from './components/application/user/profile/user-profile.component';
import { UserSettingsComponent } from './components/application/user/settings/user-settings.component';
import { UserSubscriptionsComponent } from './components/application/user/subscriptions/user-subscriptions.component';


@NgModule({
  declarations: [
    AppComponent,

    AuthLayoutComponent,
    AppLayoutComponent,

    AuthLoginComponent,
    AuthRegisterComponent,
    AuthForgotPasswordComponent,

    LayoutLeftSidebarComponent,
    LayoutTopBarComponent,
    LayoutTitleAndBreadcrumbComponent,

    DashboardComponent,
    RecentActivityChartComponent,
    BrandsOverviewComponent,
    UserProfileComponent,
    UserSettingsComponent,
    UserSubscriptionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgApexchartsModule,
  ],
  providers: [
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
